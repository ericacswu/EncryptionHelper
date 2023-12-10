namespace Aes256CbcEncrypter
{
    public partial class Aes256CbcEncrypter : Form
    {
        public Aes256CbcEncrypter()
        {
            InitializeComponent();
            this.Text = "Aes256CbcEncrypter - " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
        }

        public string GetKey()
        {
            string key = tbxKey.Text;
            return key;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (ckxEncryptFile.Checked)
            {
                DoEncryption(EncryptType.EncryptFile);
            }
            else
            {
                DoEncryption(EncryptType.Encrypt);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (ckxEncryptFile.Checked)
            {
                DoEncryption(EncryptType.DecryptFile);
            }
            else
            {
                DoEncryption(EncryptType.Decrypt);
            }
        }

        private void DoEncryption(EncryptType type)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbxKey.Text))
                {
                    MessageBox.Show("Failed", "Key value cannot be null", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!ckxEncryptFile.Checked && string.IsNullOrWhiteSpace(rtbxInput.Text))
                {
                    MessageBox.Show("Failed", "Input value cannot be null", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(ckxEncryptFile.Checked && string.IsNullOrEmpty(tbxFilePath.Text))
                {
                    MessageBox.Show("Failed", "File path cannot be null", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string result = "";
                switch (type)
                {
                    case EncryptType.Encrypt:
                        txtStatus.Text = "Encrypting...";
                        result = EncryptionHelper.Encrypt(GetKey(), rtbxInput.Text);
                        break;
                    case EncryptType.EncryptFile:
                        txtStatus.Text = "Encrypting...";
                        result = EncryptionHelper.EncryptXmlFile(GetKey(), tbxFilePath.Text);
                        break;
                    case EncryptType.Decrypt:
                        txtStatus.Text = "Decrypting...";
                        result = EncryptionHelper.Decrypt(GetKey(), rtbxInput.Text);
                        break;
                    case EncryptType.DecryptFile:
                        txtStatus.Text = "Decrypting...";
                        result = EncryptionHelper.DecryptXmlFile(GetKey(), tbxFilePath.Text);
                        break;
                    default:
                        result = string.Empty;
                        break;
                }

                if (!string.IsNullOrEmpty(result) && !result.Contains("ERROR"))
                {
                    rtbxOutput.Text = result;
                }
                else
                {
                    MessageBox.Show("Encryption Failed", result, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtStatus.Text = "Ready";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encryption Failed", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbxInput.Text = string.Empty;
            rtbxOutput.Text = string.Empty;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    tbxFilePath.Text = selectedFilePath;
                }
            }
        }

        private enum EncryptType
        {
            Encrypt,
            Decrypt,
            EncryptFile,
            DecryptFile,
        }
    }
}
