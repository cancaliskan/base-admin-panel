using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BaseAdminTemplate.Common.Helpers
{
    public static class CryptoHelper
    {
        private static readonly string key = "E546C8DF278CD5931069B522E695D4F2";

        public static string Encrypt(string data)
        {
            using (MemoryStream Memory = new MemoryStream())
            {
                using (Aes aes = Aes.Create())
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(data);
                    byte[] bKey = new byte[32];
                    Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.KeySize = 128;
                    aes.Key = bKey;

                    using (CryptoStream cryptoStream = new CryptoStream(Memory, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        try
                        {
                            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                            cryptoStream.FlushFinalBlock();
                            return Convert.ToBase64String(Memory.ToArray());
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }
            }
        }
        //public static string Encrypt(string text)
        //{
        //    //var _key = Encoding.UTF8.GetBytes(key);

        //    //using (var aes = Aes.Create())
        //    //{
        //    //    using (var encryptor = aes.CreateEncryptor(_key, aes.IV))
        //    //    {
        //    //        using (var ms = new MemoryStream())
        //    //        {
        //    //            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        //    //            {
        //    //                using (var sw = new StreamWriter(cs))
        //    //                {
        //    //                    sw.Write(text);
        //    //                }
        //    //            }

        //    //            var iv = aes.IV;
        //    //            var encrypted = ms.ToArray();
        //    //            var result = new byte[iv.Length + encrypted.Length];

        //    //            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        //    //            Buffer.BlockCopy(encrypted, 0, result, iv.Length, encrypted.Length);

        //    //            return Convert.ToBase64String(result);
        //    //        }
        //    //    }
        //    //}
        //}

        public static string Decrypt(string data)
        {
            byte[] encryptedBytes = Convert.FromBase64String(data);
            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

            using (MemoryStream Memory = new MemoryStream(encryptedBytes))
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.KeySize = 128;
                    aes.Key = bKey;

                    using (CryptoStream cryptoStream = new CryptoStream(Memory, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        try
                        {
                            byte[] tmp = new byte[encryptedBytes.Length];
                            int len = cryptoStream.Read(tmp, 0, encryptedBytes.Length);
                            byte[] ret = new byte[len];
                            Array.Copy(tmp, 0, ret, 0, len);

                            return Encoding.UTF8.GetString(ret, 0, len);
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }
            }
        }

        //public static string Decrypt(string encrypted)
        //{
        //    //var b = Convert.FromBase64String(encrypted);

        //    //var iv = new byte[16];
        //    //var cipher = new byte[16];

        //    //Buffer.BlockCopy(b, 0, iv, 0, iv.Length);
        //    //Buffer.BlockCopy(b, iv.Length, cipher, 0, iv.Length);

        //    //var _key = Encoding.UTF8.GetBytes(key);

        //    //using (var aes = Aes.Create())
        //    //{
        //    //    using (var decryptor = aes.CreateDecryptor(_key, iv))
        //    //    {
        //    //        var result = string.Empty;
        //    //        using (var ms = new MemoryStream(cipher))
        //    //        {
        //    //            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        //    //            {
        //    //                using (var sr = new StreamReader(cs))
        //    //                {
        //    //                    result = sr.ReadToEnd();
        //    //                }
        //    //            }
        //    //        }

        //    //        return result;
        //    //    }
        //    //}
        //}
    }
}