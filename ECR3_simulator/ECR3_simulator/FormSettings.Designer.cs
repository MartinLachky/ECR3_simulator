namespace ECR3_simulator
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtPort = new TextBox();
            label2 = new Label();
            txtTerminalIP = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "PORT :";
            label1.Click += label1_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(59, 33);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(85, 23);
            txtPort.TabIndex = 1;
            txtPort.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 69);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 2;
            label2.Text = "IP :";
            // 
            // txtTerminalIP
            // 
            txtTerminalIP.Location = new Point(59, 66);
            txtTerminalIP.Name = "txtTerminalIP";
            txtTerminalIP.Size = new Size(140, 23);
            txtTerminalIP.TabIndex = 3;
            txtTerminalIP.TextChanged += txtTerminalIP_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(69, 102);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(233, 134);
            Controls.Add(btnSave);
            Controls.Add(txtTerminalIP);
            Controls.Add(label2);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Name = "FormSettings";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPort;
        private Label label2;
        private TextBox txtTerminalIP;
        private Button btnSave;
    }
}