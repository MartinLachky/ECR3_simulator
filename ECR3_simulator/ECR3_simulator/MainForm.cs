using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Globalization;
using System.Data.SQLite;
using System.Collections.Generic;

namespace ECR3_simulator
{
    public partial class MainForm : Form
    {
        private string terminalIP;
        private int terminalPort;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int initialEcrId = rnd.Next(0, 100000000);
            txtEcrId.Text = initialEcrId.ToString("D8");

            terminalIP = string.IsNullOrEmpty(Properties.Settings.Default.TerminalIP)
                         ? "127.0.0.1"
                         : Properties.Settings.Default.TerminalIP;

            terminalPort = Properties.Settings.Default.TerminalPort != 0
                           ? Properties.Settings.Default.TerminalPort
                           : 5000;

            txtAmount.Text = "100,00";
            txtType.Text = "sale";
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // sem přijde reakce na klik label1 - klidně prázdné
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
                settingsForm.SetInitialValues(terminalIP, terminalPort);

                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    terminalIP = settingsForm.TerminalIP;
                    terminalPort = settingsForm.TerminalPort;

                    Properties.Settings.Default.TerminalIP = terminalIP;
                    Properties.Settings.Default.TerminalPort = terminalPort;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string ecrString = txtEcrId.Text;

            byte[] saleMessage = TerminalRequestBuilder.BuildSaleJsonMessage(
                amount: double.Parse(txtAmount.Text, CultureInfo.GetCultureInfo("cs-CZ")),
                transactionType: txtType.Text,
                ecr: ecrString
            );

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync(terminalIP, terminalPort);
                using (NetworkStream stream = client.GetStream())
                {
                    await stream.WriteAsync(saleMessage, 0, saleMessage.Length);

                    string jsonResponse = await ReceiveResponseAsync(stream);

                    FormResponse respForm = new FormResponse();
                    respForm.ShowResponse(jsonResponse);
                    respForm.Show();
                }
            }

            if (int.TryParse(txtEcrId.Text, out int ecrId))
                txtEcrId.Text = (ecrId + 1).ToString("D8");
        }

        private async Task<string> ReceiveResponseAsync(NetworkStream stream)
        {
            byte[] lengthBuffer = new byte[4];
            int bytesRead = await stream.ReadAsync(lengthBuffer, 0, 4);
            if (bytesRead < 4) throw new Exception("Incomplete length prefix.");

            if (BitConverter.IsLittleEndian)
                Array.Reverse(lengthBuffer);

            int messageLength = BitConverter.ToInt32(lengthBuffer, 0);

            byte[] messageBuffer = new byte[messageLength];
            int totalRead = 0;
            while (totalRead < messageLength)
            {
                int read = await stream.ReadAsync(messageBuffer, totalRead, messageLength - totalRead);
                if (read == 0) throw new Exception("Connection closed before full message received.");
                totalRead += read;
            }

            string jsonResponse = Encoding.UTF8.GetString(messageBuffer);

            try
            {
                string cleanedJson = jsonResponse.Replace("\"base\":", "\"baseAmount\":");
                Root parsed = JsonConvert.DeserializeObject<Root>(cleanedJson);

                if (parsed != null)
                {
                    StoreTerminalResponse(parsed, jsonResponse);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Response parse/store error: " + ex.Message);
            }

            return jsonResponse;
        }

        private void StoreTerminalResponse(Root parsed, string rawJson)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ecrId = parsed?.response?.financial?.id?.ecr ?? "";
            double amount = parsed?.response?.financial?.amounts?.baseAmount ?? 0.0;
            string currency = parsed?.response?.financial?.amounts?.currencyCode ?? "";
            string code = parsed?.response?.financial?.result?.code ?? "";
            string message = parsed?.response?.financial?.result?.message ?? "";

            using (var conn = new SQLiteConnection("Data Source=responses.db"))
            {
                conn.Open();
                string sql = @"INSERT INTO TerminalResponses 
                               (Timestamp, EcrId, Amount, Currency, ApprovalCode, ApprovalMessage, RawJson)
                               VALUES (@ts, @ecr, @amount, @cur, @code, @msg, @json)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ts", timestamp);
                    cmd.Parameters.AddWithValue("@ecr", ecrId);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@cur", currency);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@msg", message);
                    cmd.Parameters.AddWithValue("@json", rawJson);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 📌 New: Drop-down recent transactions
        private void btnRecentTransactions_Click(object sender, EventArgs e)
        {
            // Create embedded ListView
            ListView lv = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                Width = 350,
                Height = 200
            };
            lv.Columns.Add("Date/Time", 120);
            lv.Columns.Add("ECR ID", 80);
            lv.Columns.Add("Amount", 80);
            lv.Columns.Add("Currency", 60);

            var txns = GetRecentTransactions(10);
            foreach (var t in txns)
            {
                var item = new ListViewItem(t.Timestamp);
                item.SubItems.Add(t.EcrId);
                item.SubItems.Add(t.Amount.ToString("F2"));
                item.SubItems.Add(t.Currency);
                item.Tag = t.EcrId;
                lv.Items.Add(item);
            }

            lv.DoubleClick += (s, ev) =>
            {
                if (lv.SelectedItems.Count == 0) return;
                string ecrId = lv.SelectedItems[0].Tag.ToString();
                var rawJson = GetRawJsonByEcrId(ecrId);
                if (!string.IsNullOrWhiteSpace(rawJson))
                {
                    FormResponse resp = new FormResponse();
                    resp.ShowResponse(rawJson);
                    resp.Show();
                }
                ((ToolStripDropDown)((Control)s).Parent).Close();
            };

            ToolStripControlHost host = new ToolStripControlHost(lv)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false
            };
            ToolStripDropDown dropDown = new ToolStripDropDown
            {
                Padding = Padding.Empty
            };
            dropDown.Items.Add(host);
            dropDown.Show(btnRecentTransactions, new Point(0, btnRecentTransactions.Height));
        }

        // ---------------- HELPERS ----------------

        public class TransactionRecord
        {
            public int Id { get; set; }
            public string Timestamp { get; set; }
            public string EcrId { get; set; }
            public double Amount { get; set; }
            public string Currency { get; set; }
        }

        private List<TransactionRecord> GetRecentTransactions(int count = 10)
        {
            var results = new List<TransactionRecord>();
            using (var conn = new SQLiteConnection("Data Source=responses.db"))
            {
                conn.Open();
                string sql = $"SELECT Id, Timestamp, EcrId, Amount, Currency FROM TerminalResponses ORDER BY Id DESC LIMIT {count}";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new TransactionRecord
                        {
                            Id = reader.GetInt32(0),
                            Timestamp = reader.GetString(1),
                            EcrId = reader.GetString(2),
                            Amount = reader.GetDouble(3),
                            Currency = reader.GetString(4)
                        });
                    }
                }
            }
            return results;
        }

        private string GetRawJsonByEcrId(string ecrId)
        {
            using (var conn = new SQLiteConnection("Data Source=responses.db"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT RawJson FROM TerminalResponses WHERE EcrId = @ecrId", conn))
                {
                    cmd.Parameters.AddWithValue("@ecrId", ecrId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? reader.GetString(0) : null;
                    }
                }
            }
        }
    }
}
