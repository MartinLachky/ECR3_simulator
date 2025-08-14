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
            this.rtbResponseDisplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbResponseDisplay
            // 
            this.rtbResponseDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResponseDisplay.Location = new System.Drawing.Point(0, 0);
            this.rtbResponseDisplay.Name = "rtbResponseDisplay";
            this.rtbResponseDisplay.ReadOnly = true;
            this.rtbResponseDisplay.Size = new System.Drawing.Size(584, 361);
            this.rtbResponseDisplay.TabIndex = 0;
            this.rtbResponseDisplay.Text = "";
            this.rtbResponseDisplay.TextChanged += new System.EventHandler(this.rtbResponseDisplay_TextChanged);
            // 
            // FormResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.rtbResponseDisplay);
            this.Name = "FormResponse";
            this.Text = "Terminal Response";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbResponseDisplay;
    }
}
