using System.IO;
using System.Security.Cryptography;

namespace DocumentEncrypter
{
    class AESEncryption
    {
        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        public byte[] saltBytes = new byte[] { 111, 24, 33, 41, 52, 67, 83, 14 };
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Create memory stream object
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    // Setup Key Size and blocksize here, currently set for 256 bit encryption
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    // Generate key using password and salt
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    //Set cipher mode to be used
                    AES.Mode = CipherMode.CBC;

                    using (var cryptoStream = new CryptoStream(memoryStream, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cryptoStream.Close();
                    }
                    encryptedBytes = memoryStream.ToArray();
                }
            }

            return encryptedBytes;
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    // Generate key using password and salt
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cryptoStream = new CryptoStream(memoryStream, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cryptoStream.Close();
                    }
                    decryptedBytes = memoryStream.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
