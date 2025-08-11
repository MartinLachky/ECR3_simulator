using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECR3_simulator
{
    public partial class MainForm : Form
    {
        private string terminalIP;
        private int terminalPort;
        private int baseEcrId;
        private int currentIncrement = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int initialEcrId = rnd.Next(0, 100000000); // from 0 to 99,999,999
            txtEcrId.Text = initialEcrId.ToString("D8");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings settingsForm = new FormSettings())
            {
                if (!string.IsNullOrEmpty(terminalIP))
                    settingsForm.SetInitialValues(terminalIP, terminalPort);

                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    terminalIP = settingsForm.TerminalIP;
                    terminalPort = settingsForm.TerminalPort;
                }
            }
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string ecrString = txtEcrId.Text;

            byte[] saleMessage = TerminalRequestBuilder.BuildSaleJsonMessage(
                amount: double.Parse(txtAmount.Text),
                transactionType: txtType.SelectedItem?.ToString(),
                ecr: ecrString
            );

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync(terminalIP, terminalPort);
                using (NetworkStream stream = client.GetStream())
                {
                    // Send
                    await stream.WriteAsync(saleMessage, 0, saleMessage.Length);

                    // Receive
                    string jsonResponse = await ReceiveResponseAsync(stream);

                    // Show
                    FormResponse respForm = new FormResponse();
                    respForm.ShowResponse(jsonResponse);
                    respForm.Show();
                }
            }

            // Increment ECR and prepare for next run
            if (int.TryParse(txtEcrId.Text, out int ecrId))
                txtEcrId.Text = (ecrId + 1).ToString("D8");
        }




        private string SimulateTerminalResponse(string requestJson)
        {
            // A fake terminal JSON response
            var responseObj = new
            {
                status = "success",
                message = "Transaction completed",
                timestamp = DateTime.Now
            };

            return JsonConvert.SerializeObject(responseObj, Formatting.Indented);
        }
        private async Task<string> ReceiveResponseAsync(NetworkStream stream)
        {
            // Read 4 bytes for length (big-endian)
            byte[] lengthBuffer = new byte[4];
            int bytesRead = await stream.ReadAsync(lengthBuffer, 0, 4);
            if (bytesRead < 4) throw new Exception("Incomplete length prefix.");

            if (BitConverter.IsLittleEndian)
                Array.Reverse(lengthBuffer);

            int messageLength = BitConverter.ToInt32(lengthBuffer, 0);

            // Read exactly 'messageLength' bytes
            byte[] messageBuffer = new byte[messageLength];
            int totalRead = 0;
            while (totalRead < messageLength)
            {
                int read = await stream.ReadAsync(messageBuffer, totalRead, messageLength - totalRead);
                if (read == 0) throw new Exception("Connection closed before full message received.");
                totalRead += read;
            }

            return Encoding.UTF8.GetString(messageBuffer);
        }

        private void txtEcrId_TextChanged(object sender, EventArgs e)
        {
            // User changing value doesn't alter internal counting logic
            // We just allow them to type freely and ignore unless needed for display
        }


    }
}
