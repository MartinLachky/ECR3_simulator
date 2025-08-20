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
            btnRecentTransactions = new Button();
            label3 = new Label();
            txtTip = new TextBox();
            label4 = new Label();
            txtCb = new TextBox();
            label5 = new Label();
            txtCurrency = new ComboBox();
            label6 = new Label();
            txtLanguage = new ComboBox();
            label7 = new Label();
            txtPrinting = new ComboBox();
            btnSettlement = new Button();
            btnStatus = new Button();
            label8 = new Label();
            txtInvoice = new TextBox();
            label9 = new Label();
            txtReference = new TextBox();
            label10 = new Label();
            txtSequence = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 100);
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
            txtType.Items.AddRange(new object[] { "sale", "refund", "preauthorization", "void", "preauth-completion" });
            txtType.Location = new Point(162, 68);
            txtType.Name = "txtType";
            txtType.Size = new Size(114, 23);
            txtType.TabIndex = 1;
            txtType.SelectedIndexChanged += txtType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 71);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 2;
            label2.Text = "Transaction Type";
            label2.Click += label2_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(162, 97);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(169, 23);
            txtAmount.TabIndex = 3;
            txtAmount.TextChanged += textBox1_TextChanged;
            // 
            // ECR_ID
            // 
            ECR_ID.AutoSize = true;
            ECR_ID.Location = new Point(105, 153);
            ECR_ID.Name = "ECR_ID";
            ECR_ID.Size = new Size(42, 15);
            ECR_ID.TabIndex = 5;
            ECR_ID.Text = "ECR ID";
            ECR_ID.Click += label3_Click;
            // 
            // txtEcrId
            // 
            txtEcrId.Location = new Point(162, 153);
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
            btnSend.Location = new Point(122, 441);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(194, 67);
            btnSend.TabIndex = 8;
            btnSend.Text = "Send request";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnRecentTransactions
            // 
            btnRecentTransactions.Location = new Point(363, 2);
            btnRecentTransactions.Name = "btnRecentTransactions";
            btnRecentTransactions.Size = new Size(82, 23);
            btnRecentTransactions.TabIndex = 10;
            btnRecentTransactions.Text = "Last Transactions ▼";
            btnRecentTransactions.UseVisualStyleBackColor = true;
            btnRecentTransactions.Click += btnRecentTransactions_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 185);
            label3.Name = "label3";
            label3.Size = new Size(23, 15);
            label3.TabIndex = 11;
            label3.Text = "TIP";
            // 
            // txtTip
            // 
            txtTip.Location = new Point(162, 182);
            txtTip.Name = "txtTip";
            txtTip.Size = new Size(135, 23);
            txtTip.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 214);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 13;
            label4.Text = "Cashback";
            label4.Click += label4_Click;
            // 
            // txtCb
            // 
            txtCb.Location = new Point(162, 211);
            txtCb.Name = "txtCb";
            txtCb.Size = new Size(135, 23);
            txtCb.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(89, 127);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 15;
            label5.Text = "Currency";
            // 
            // txtCurrency
            // 
            txtCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCurrency.FormattingEnabled = true;
            txtCurrency.Items.AddRange(new object[] { "CZK", "EUR", "HUF", "RON", "RUB", "GBP" });
            txtCurrency.Location = new Point(162, 124);
            txtCurrency.Name = "txtCurrency";
            txtCurrency.Size = new Size(70, 23);
            txtCurrency.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(89, 243);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 17;
            label6.Text = "Language";
            // 
            // txtLanguage
            // 
            txtLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            txtLanguage.FormattingEnabled = true;
            txtLanguage.Items.AddRange(new object[] { "cs", "en", "de", "sk", "es", "fr", "hu", "it", "ro" });
            txtLanguage.Location = new Point(162, 240);
            txtLanguage.Name = "txtLanguage";
            txtLanguage.Size = new Size(51, 23);
            txtLanguage.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 275);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 19;
            label7.Text = "Print on POS";
            // 
            // txtPrinting
            // 
            txtPrinting.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPrinting.FormattingEnabled = true;
            txtPrinting.Items.AddRange(new object[] { "true", "false" });
            txtPrinting.Location = new Point(162, 272);
            txtPrinting.Name = "txtPrinting";
            txtPrinting.Size = new Size(66, 23);
            txtPrinting.TabIndex = 20;
            // 
            // btnSettlement
            // 
            btnSettlement.Location = new Point(171, 2);
            btnSettlement.Name = "btnSettlement";
            btnSettlement.Size = new Size(103, 24);
            btnSettlement.TabIndex = 21;
            btnSettlement.Text = "Settlement";
            btnSettlement.UseVisualStyleBackColor = true;
            btnSettlement.Click += btnSettle_Click;
            // 
            // btnStatus
            // 
            btnStatus.Location = new Point(122, 527);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(194, 24);
            btnStatus.TabIndex = 22;
            btnStatus.Text = "Status info";
            btnStatus.UseVisualStyleBackColor = true;
            btnStatus.Click += btnStatus_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(100, 304);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 23;
            label8.Text = "Invoice";
            label8.Click += label8_Click;
            // 
            // txtInvoice
            // 
            txtInvoice.Location = new Point(162, 301);
            txtInvoice.Name = "txtInvoice";
            txtInvoice.Size = new Size(79, 23);
            txtInvoice.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(53, 336);
            label9.Name = "label9";
            label9.Size = new Size(104, 15);
            label9.TabIndex = 25;
            label9.Text = "Reference number";
            // 
            // txtReference
            // 
            txtReference.Location = new Point(162, 333);
            txtReference.Name = "txtReference";
            txtReference.Size = new Size(112, 23);
            txtReference.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(54, 366);
            label10.Name = "label10";
            label10.Size = new Size(103, 15);
            label10.TabIndex = 27;
            label10.Text = "Sequence number";
            // 
            // txtSequence
            // 
            txtSequence.Location = new Point(162, 363);
            txtSequence.Name = "txtSequence";
            txtSequence.Size = new Size(110, 23);
            txtSequence.TabIndex = 28;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(457, 579);
            Controls.Add(txtSequence);
            Controls.Add(label10);
            Controls.Add(txtReference);
            Controls.Add(label9);
            Controls.Add(txtInvoice);
            Controls.Add(label8);
            Controls.Add(btnStatus);
            Controls.Add(btnSettlement);
            Controls.Add(txtPrinting);
            Controls.Add(label7);
            Controls.Add(txtLanguage);
            Controls.Add(label6);
            Controls.Add(txtCurrency);
            Controls.Add(label5);
            Controls.Add(txtCb);
            Controls.Add(label4);
            Controls.Add(txtTip);
            Controls.Add(label3);
            Controls.Add(btnRecentTransactions);
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
            Text = "Simulator 1.0.0";
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
        private Button btnRecentTransactions;
        private Label label3;
        private TextBox txtTip;
        private Label label4;
        private TextBox txtCb;
        private Label label5;
        private ComboBox txtCurrency;
        private Label label6;
        private ComboBox txtLanguage;
        private Label label7;
        private ComboBox txtPrinting;
        private Button btnSettlement;
        private Button btnStatus;
        private Label label8;
        private TextBox txtInvoice;
        private Label label9;
        private TextBox txtReference;
        private Label label10;
        private TextBox txtSequence;
    }
}
