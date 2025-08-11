using System;
using System.Windows.Forms;

namespace ECR3_simulator
{
    public partial class FormResponse : Form
    {
        public FormResponse()
        {
            InitializeComponent();
        }

        public void ShowResponse(string responseData)
        {
            rtbResponseDisplay.Text = responseData;
        }

        private void rtbResponseDisplay_TextChanged(object sender, EventArgs e)
        {
            // Optional: add logic if you want to react to text changes
        }
    }

}
