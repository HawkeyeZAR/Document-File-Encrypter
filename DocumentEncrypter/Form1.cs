using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace DocumentEncrypter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Files",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog1.FileName;
                //Check to see if file has already been encrypted
                bool encryptedStatus = CheckIfEncrypted();
                //Reset Label and color back to defaults
                statusLabel.ForeColor = System.Drawing.Color.Black;
                statusLabel.Text = "Status:";

                //If not encrypted, disable decrypt button, enable encrypt button and update statusLabel
                if (!encryptedStatus)
                {
                    encryptFileBtn.Enabled = true;
                    statusLabel.ForeColor = System.Drawing.Color.Green;
                    statusLabel.Text = "Status: File not encrypted";
                }
                //If allready encrypted, disable encrypt button, enable decrypt button and update statusLabel
                else
                {
                    decryptFileBtn.Enabled = true;
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                    statusLabel.Text = "Status: File is encrypted";
                }
            }
            else
            {
                // If OpenFileDialog has been cancelled, reset everything back to defualts
                fileNameTextBox.Text = "";
                encryptFileBtn.Enabled = false;
                decryptFileBtn.Enabled = false;
                statusLabel.ForeColor = System.Drawing.Color.Black;
                statusLabel.Text = "Status:";
            }
        }

        private void encryptFileBtn_Click(object sender, EventArgs e)
        {
            //Call encrypt file method and update buttons and statusLabel
            EncryptFile(); 
            encryptFileBtn.Enabled = false;
            decryptFileBtn.Enabled = true;
            statusLabel.ForeColor = System.Drawing.Color.Red;
            statusLabel.Text = "Status: File is now encrypted";
        }

        private void decryptFileBtn_Click(object sender, EventArgs e)
        {
            //Call decrypt file method and update buttons and statusLabel
            DecryptFile();
            decryptFileBtn.Enabled = false;
            encryptFileBtn.Enabled = true;
            statusLabel.ForeColor = System.Drawing.Color.Green;
            statusLabel.Text = "Status: File has been decrypted";
        }

        // Method to check if file is encrypted
        public bool CheckIfEncrypted()
        {
            string file = fileNameTextBox.Text;
            byte[] fileData = File.ReadAllBytes(file);
            byte[] signature = Encoding.UTF8.GetBytes("Encrypted");
            // Compare byte signature to first 9 bytes (length of signature) of file data
            bool encrypted = signature.SequenceEqual(fileData.Take(9).ToArray());
            // Return True if signature found in data else return false
            return encrypted;
        }

        AESEncryption aesEncryption = new AESEncryption();

        // Method to Encrypte file data and to add encryption signature to data
        public void EncryptFile()
        {
            string file = fileNameTextBox.Text;
            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            //Create password in bytes to be used for encryption
            byte[] passwordBytes = new byte[] {111, 89, 218, 174, 87, 20, 108, 14};

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            // Call AES_Encrypt Method
            byte[] bytesEncrypted = aesEncryption.AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string fileEncrypted = fileNameTextBox.Text;
            // Create encryption signature to add to file to be used for identification
            byte[] signature = Encoding.UTF8.GetBytes("Encrypted");
            // Add signature to encrypted data and save to a file
            File.WriteAllBytes(fileEncrypted, signature.Concat(bytesEncrypted).ToArray());
        }

        // Method to Decrypte file data and to remove the encryption signature from the data
        public void DecryptFile()
        {
            string fileEncrypted = fileNameTextBox.Text;
            byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted);
            //Create password in bytes to be used for decryption
            byte[] passwordBytes = new byte[] { 111, 89, 218, 174, 87, 20, 108, 14 };
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            //Remove Signature from data before decryption
            byte[] removedSignature = bytesToBeDecrypted.Skip(9).ToArray();

            //Call AES_Decrypt method with encrypted data minus signature header
            byte[] bytesDecrypted = aesEncryption.AES_Decrypt(removedSignature, passwordBytes);
            string file = fileNameTextBox.Text;
            // Save decrypted data back to a file
            File.WriteAllBytes(file, bytesDecrypted);
        }


    }
}
