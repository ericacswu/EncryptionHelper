namespace Aes256CbcEncrypter
{
    partial class Aes256CbcEncrypter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aes256CbcEncrypter));
            tbxKey = new TextBox();
            gbxAll = new GroupBox();
            btnClear = new Button();
            btnDecrypt = new Button();
            btnEncrypt = new Button();
            lblOutput = new Label();
            lblInput = new Label();
            lblKey = new Label();
            rtbxOutput = new RichTextBox();
            rtbxInput = new RichTextBox();
            statusBar = new StatusStrip();
            txtStatus = new ToolStripStatusLabel();
            gbxAll.SuspendLayout();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // tbxKey
            // 
            tbxKey.Location = new Point(102, 36);
            tbxKey.Name = "tbxKey";
            tbxKey.Size = new Size(310, 23);
            tbxKey.TabIndex = 1;
            // 
            // gbxAll
            // 
            gbxAll.Controls.Add(btnClear);
            gbxAll.Controls.Add(btnDecrypt);
            gbxAll.Controls.Add(btnEncrypt);
            gbxAll.Controls.Add(lblOutput);
            gbxAll.Controls.Add(lblInput);
            gbxAll.Controls.Add(lblKey);
            gbxAll.Controls.Add(rtbxOutput);
            gbxAll.Controls.Add(rtbxInput);
            gbxAll.Controls.Add(tbxKey);
            gbxAll.Dock = DockStyle.Fill;
            gbxAll.ForeColor = SystemColors.Control;
            gbxAll.Location = new Point(0, 0);
            gbxAll.Name = "gbxAll";
            gbxAll.Size = new Size(464, 371);
            gbxAll.TabIndex = 1;
            gbxAll.TabStop = false;
            gbxAll.Text = "Encryption";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(45, 45, 45);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(324, 286);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(88, 38);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.BackColor = Color.FromArgb(45, 45, 45);
            btnDecrypt.FlatAppearance.BorderSize = 0;
            btnDecrypt.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            btnDecrypt.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            btnDecrypt.FlatStyle = FlatStyle.Flat;
            btnDecrypt.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDecrypt.Location = new Point(213, 286);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(105, 38);
            btnDecrypt.TabIndex = 5;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = false;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnEncrypt
            // 
            btnEncrypt.BackColor = Color.FromArgb(45, 45, 45);
            btnEncrypt.FlatAppearance.BorderSize = 0;
            btnEncrypt.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 20, 20);
            btnEncrypt.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
            btnEncrypt.FlatStyle = FlatStyle.Flat;
            btnEncrypt.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEncrypt.Location = new Point(102, 286);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(105, 38);
            btnEncrypt.TabIndex = 4;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = false;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(29, 174);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(45, 15);
            lblOutput.TabIndex = 0;
            lblOutput.Text = "Output";
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new Point(29, 68);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(35, 15);
            lblInput.TabIndex = 0;
            lblInput.Text = "Input";
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(29, 39);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(27, 15);
            lblKey.TabIndex = 0;
            lblKey.Text = "KEY";
            // 
            // rtbxOutput
            // 
            rtbxOutput.Location = new Point(102, 171);
            rtbxOutput.Name = "rtbxOutput";
            rtbxOutput.Size = new Size(310, 100);
            rtbxOutput.TabIndex = 3;
            rtbxOutput.Text = "";
            // 
            // rtbxInput
            // 
            rtbxInput.Location = new Point(102, 65);
            rtbxInput.Name = "rtbxInput";
            rtbxInput.Size = new Size(310, 100);
            rtbxInput.TabIndex = 2;
            rtbxInput.Text = "";
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new ToolStripItem[] { txtStatus });
            statusBar.Location = new Point(0, 349);
            statusBar.Name = "statusBar";
            statusBar.RenderMode = ToolStripRenderMode.Professional;
            statusBar.Size = new Size(464, 22);
            statusBar.TabIndex = 0;
            statusBar.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            txtStatus.ForeColor = SystemColors.ControlText;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(39, 17);
            txtStatus.Text = "Ready";
            // 
            // Aes256CbcEncrypter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(464, 371);
            Controls.Add(statusBar);
            Controls.Add(gbxAll);
            ForeColor = SystemColors.Window;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(480, 410);
            Name = "Aes256CbcEncrypter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aes256CbcEncrypter";
            gbxAll.ResumeLayout(false);
            gbxAll.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxKey;
        private GroupBox gbxAll;
        private RichTextBox rtbxOutput;
        private RichTextBox rtbxInput;
        private Label lblOutput;
        private Label lblInput;
        private Label lblKey;
        private Button btnDecrypt;
        private Button btnEncrypt;
        private StatusStrip statusBar;
        private ToolStripProgressBar progressBar;
        private ToolStripStatusLabel txtStatus;
        private Button btnClear;
    }
}
