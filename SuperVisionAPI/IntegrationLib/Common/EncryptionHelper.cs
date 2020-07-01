using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib.Common
{
    public static class EncryptionHelper
    {
        private static string config_salt = Convert.ToString(ConfigurationManager.AppSettings["sec-salt"]);
        private static string config_key = Convert.ToString(ConfigurationManager.AppSettings["sec-pwd"]);
        public static string Encrypt(string input, string key=null, string salt=null)
        {
            key = (string.IsNullOrEmpty(key)? config_key:key);
            salt = (string.IsNullOrEmpty(salt) ? config_key : salt);
            key = (string.IsNullOrEmpty(key) ? "ENCRY-SECUR-PWD" : key);
            salt = (string.IsNullOrEmpty(salt) ? "Y;lqaq`kMFtjHdk@I@Aq" : salt);
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(input);
            byte[] saltBytes = System.Text.Encoding.Unicode.GetBytes(salt);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, saltBytes);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    input = Convert.ToBase64String(ms.ToArray());
                }
            }
            return input;
        }
        public static string Decrypt(string cipherText, string key=null, string salt=null)
        {
            key = (string.IsNullOrEmpty(key) ? config_key : key);
            salt = (string.IsNullOrEmpty(salt) ? config_key : salt);
            key = (string.IsNullOrEmpty(key) ? "ENCRY-SECUR-PWD" : key);
            salt = (string.IsNullOrEmpty(salt) ? "Y;lqaq`kMFtjHdk@I@Aq" : key);
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] saltBytes = System.Text.Encoding.Unicode.GetBytes(salt);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, saltBytes);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
