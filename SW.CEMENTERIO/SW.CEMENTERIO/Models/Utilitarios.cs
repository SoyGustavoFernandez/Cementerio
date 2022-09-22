using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace SW.CEMENTERIO.Models
{
    public class Utilitarios
    {
        internal static string NumeroAletorio()
        {
            return new Random().Next(10000, 99999).ToString();
        }

        public static string EncryptTripleDES(string Plaintext, string strKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(Plaintext);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(strKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    Plaintext = Convert.ToBase64String(ms.ToArray());
                }
            }
            return Plaintext;
        }

        public static string DecryptTripleDES(string base64Text, string strKey, byte[] IV)
        {
            base64Text = base64Text.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(base64Text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(strKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    base64Text = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return base64Text;
        }
    }
}