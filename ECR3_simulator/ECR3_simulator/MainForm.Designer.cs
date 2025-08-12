namespace ECR3_simulator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtType = new ComboBox();
            label2 = new Label();
            txtAmount = new TextBox();
            ECR_ID = new Label();
            txtEcrId = new TextBox();
            btnSettings = new Button();
            btnSend = new Button();
            lstRecentTransactions = new ListView();
            btnRecentTransactions = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 76);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Amount";
            label1.Click += label1_Click;
            // 
            // txtType
            // 
            txtType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtType.FormattingEnabled = true;
            txtType.Items.AddRange(new object[] { "sale", "refund", "preauthorization", "void" });
            txtType.Location = new Point(107, 47);
            txtType.Name = "txtType";
            txtType.Size = new Size(114, 23);
            txtType.TabIndex = 1;
            txtType.SelectedIndexChanged += txtType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 50);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 2;
            label2.Text = "Transaction Type";
            label2.Click += label2_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(107, 73);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(169, 23);
            txtAmount.TabIndex = 3;
            txtAmount.TextChanged += textBox1_TextChanged;
            // 
            // ECR_ID
            // 
            ECR_ID.AutoSize = true;
            ECR_ID.Location = new Point(48, 103);
            ECR_ID.Name = "ECR_ID";
            ECR_ID.Size = new Size(42, 15);
            ECR_ID.TabIndex = 5;
            ECR_ID.Text = "ECR ID";
            ECR_ID.Click += label3_Click;
            // 
            // txtEcrId
            // 
            txtEcrId.Location = new Point(107, 100);
            txtEcrId.Name = "txtEcrId";
            txtEcrId.Size = new Size(135, 23);
            txtEcrId.TabIndex = 6;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(7, 2);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(66, 23);
            btnSettings.TabIndex = 7;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(63, 241);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(194, 67);
            btnSend.TabIndex = 8;
            btnSend.Text = "Send request";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lstRecentTransactions
            // 
            lstRecentTransactions.FullRowSelect = true;
            lstRecentTransactions.Location = new Point(7, 314);
            lstRecentTransactions.MultiSelect = false;
            lstRecentTransactions.Name = "lstRecentTransactions";
            lstRecentTransactions.Size = new Size(360, 59);
            lstRecentTransactions.TabIndex = 9;
            lstRecentTransactions.UseCompatibleStateImageBehavior = false;
            lstRecentTransactions.View = View.Details;
            // 
            // btnRecentTransactions
            // 
            btnRecentTransactions.Location = new Point(285, 2);
            btnRecentTransactions.Name = "btnRecentTransactions";
            btnRecentTransactions.Size = new Size(82, 28);
            btnRecentTransactions.TabIndex = 10;
            btnRecentTransactions.Text = "Last Transactions ▼";
            btnRecentTransactions.UseVisualStyleBackColor = true;
            btnRecentTransactions.Click += btnRecentTransactions_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(379, 385);
            Controls.Add(btnRecentTransactions);
            Controls.Add(lstRecentTransactions);
            Controls.Add(btnSend);
            Controls.Add(btnSettings);
            Controls.Add(txtEcrId);
            Controls.Add(ECR_ID);
            Controls.Add(txtAmount);
            Controls.Add(label2);
            Controls.Add(txtType);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox txtType;
        private Label label2;
        private TextBox txtAmount;
        private Label ECR_ID;
        private TextBox txtEcrId;
        private Button btnSettings;
        private Button btnSend;
        private ListView lstRecentTransactions;
        private Button btnRecentTransactions;
    }
}
