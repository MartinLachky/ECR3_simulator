using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR3_simulator
{
    public partial class FormSettings : Form
    {
        public string TerminalIP { get; private set; }
        public int TerminalPort { get; private set; }

        public FormSettings()
        {
            InitializeComponent();
        }

        // Optional: pre-fill fields when dialog opens
        public void SetInitialValues(string ip, int port)
        {
            txtTerminalIP.Text = ip;
            txtPort.Text = port.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TerminalIP = txtTerminalIP.Text;
            int.TryParse(txtPort.Text, out int port);
            TerminalPort = port;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
