using Newtonsoft.Json;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Aes256CbcEncrypter
{
    public static class EncryptionHelper
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static string Encrypt(string key, string plainText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Mode = CipherMode.CBC;

                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.GenerateIV();

                    ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                    byte[] buffer = Encoding.UTF8.GetBytes(plainText);

                    string encryptedText = Convert.ToBase64String(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));

                    string mac = BitConverter.ToString(HmacSHA256(Convert.ToBase64String(aes.IV) + encryptedText, key)).Replace("-", "").ToLower();

                    var keyValues = new Dictionary<string, object>
                    {
                        { "iv", Convert.ToBase64String(aes.IV) },
                        { "value", encryptedText },
                        { "mac", mac },
                    };
                    return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(keyValues)));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error encrypting: " + e.Message);
            }
        }

        public static string EncryptXmlFile(string sKey, string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                List<string> conKey = new List<string>()
                    {
                        "DB_Host",
                        "DB_Schema",
                        "DB_UserName",
                        "DB_WR",
                        "DB_ELK_EndPointType",
                        "DB_ELK_EndPointName",
                        "DB_ELK_Account",
                        "DB_ELK_Container",
                        "DB_ELK_TimeoutMS",
                    };

                // Assuming your XML structure looks like <configuration><appSettings><add key="..." value="..."/>
                XmlNodeList? appSettingsNodes = xmlDoc.SelectNodes("/configuration/appSettings/add");
                if (appSettingsNodes != null)
                {
                    foreach (XmlElement element in appSettingsNodes)
                    {
                        string eKey = "";
                        string key = element.GetAttribute("key");
                        string value = element.GetAttribute("value");

                        if (key == "OBankMode") continue;

                        if (conKey.Contains(key))
                        {
                            eKey = "9cd52908a0de102519bb6019aed0bc51";
                        }
                        else
                        {
                            eKey = sKey;
                        }
                        value = Encrypt(eKey, value);
                        // Modify values as needed
                        element.SetAttribute("value", value);
                    }
                }

                xmlDoc.Save(filePath);

                return "Encrypt Success";
            }
            catch (Exception ex)
            {
                return "Error updating XML values: " + ex.Message;
            }
        }

        public static string Decrypt(string key, string cipherText)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Mode = CipherMode.CBC;
                    aes.Key = Encoding.UTF8.GetBytes(key);

                    // Base 64 decode
                    byte[] base64Decoded = Convert.FromBase64String(cipherText);
                    string base64DecodedStr = Encoding.UTF8.GetString(base64Decoded);

                    // JSON Decode base64Str
                    var payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(base64DecodedStr);

                    aes.IV = Convert.FromBase64String(payload["iv"]);

                    ICryptoTransform AESDecrypt = aes.CreateDecryptor(aes.Key, aes.IV);
                    byte[] buffer = Convert.FromBase64String(payload["value"]);

                    return Encoding.UTF8.GetString(AESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error decrypting: " + e.Message);
            }
        }

        public static string DecryptXmlFile(string sKey, string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                List<string> conKey = new List<string>()
                    {
                        "DB_Host",
                        "DB_Schema",
                        "DB_UserName",
                        "DB_WR",
                        "DB_ELK_EndPointType",
                        "DB_ELK_EndPointName",
                        "DB_ELK_Account",
                        "DB_ELK_Container",
                        "DB_ELK_TimeoutMS",
                    };

                // Assuming your XML structure looks like <configuration><appSettings><add key="..." value="..."/>
                XmlNodeList? appSettingsNodes = xmlDoc.SelectNodes("/configuration/appSettings/add");
                if (appSettingsNodes != null)
                {
                    foreach (XmlElement element in appSettingsNodes)
                    {
                        string eKey = "";
                        string key = element.GetAttribute("key");
                        string value = element.GetAttribute("value");

                        if (key == "OBankMode") continue;

                        if (conKey.Contains(key))
                        {
                            eKey = "9cd52908a0de102519bb6019aed0bc51";
                        }
                        else
                        {
                            eKey = sKey;
                        }
                        value = Decrypt(eKey, value);
                        // Modify values as needed
                        element.SetAttribute("value", value);
                    }
                }

                xmlDoc.Save(filePath);

                return "Decrypt Success";
            }
            catch (Exception ex)
            {
                return "Error updating XML values: " + ex.Message;
            }
        }

        static byte[] HmacSHA256(String data, String key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(encoding.GetBytes(key)))
            {
                return hmac.ComputeHash(encoding.GetBytes(data));
            }
        }
    }
}
