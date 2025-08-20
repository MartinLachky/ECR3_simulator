namespace ECR3_simulator
{
    partial class FormResponse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            rtbResponseDisplay = new RichTextBox();
            SuspendLayout();
            // 
            // rtbResponseDisplay
            // 
            rtbResponseDisplay.Dock = DockStyle.Fill;
            rtbResponseDisplay.Location = new Point(0, 0);
            rtbResponseDisplay.Name = "rtbResponseDisplay";
            rtbResponseDisplay.ReadOnly = true;
            rtbResponseDisplay.Size = new Size(286, 561);
            rtbResponseDisplay.TabIndex = 0;
            rtbResponseDisplay.Text = "";
            rtbResponseDisplay.TextChanged += rtbResponseDisplay_TextChanged;
            // 
            // FormResponse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 561);
            Controls.Add(rtbResponseDisplay);
            Name = "FormResponse";
            Text = "Terminal Response";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbResponseDisplay;
    }
}
