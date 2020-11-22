using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Cookie.API.Utils.IO;

namespace Cookie.API.Utils.Cryptography
{
    public static class AES
    {
        private static readonly int _iterations;
        private static readonly int _keySize;
        private static readonly string _hash;
        private static readonly string _salt;
        private static readonly string _vector;
        private static string gameTicket;

        static AES()
        {
            _iterations = 2;
            _keySize = 256;
            _hash = "SHA1";
            _salt = "astr7ias38490a98";
            _vector = "8947az34zyl34kjq";
        }

        public static string Encrypt(string value, string password)
        {
            return Encrypt<AesManaged>(value, password);
        }

        public static string Encrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            var bytes1 = Encoding.ASCII.GetBytes(_vector);
            var bytes2 = Encoding.ASCII.GetBytes(_salt);
            var bytes3 = Encoding.UTF8.GetBytes(value);
            var instance = Activator.CreateInstance<T>();
            byte[] array;
            try
            {
                var bytes4 = new PasswordDeriveBytes(password, bytes2, _hash, _iterations).GetBytes(_keySize / 8);
                instance.Mode = CipherMode.CBC;
                using (var encryptor = instance.CreateEncryptor(bytes4, bytes1))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes3, 0, bytes3.Length);
                            cryptoStream.FlushFinalBlock();
                            array = memoryStream.ToArray();
                        }
                    }
                }
                instance.Clear();
            }
            finally
            {
                if (instance != null)
                    instance.Dispose();
            }
            return Convert.ToBase64String(array);
        }

        public static string Decrypt(string value, string password)
        {
            return Decrypt<AesManaged>(value, password);
        }

        public static string DecodeWithAES(List<sbyte> ticket)
        {
            var dr = new BigEndianReader(new byte[32]);
            var aesAlg = new AesManaged();

            var ticketbyte = new byte[ticket.Count];
            for (var i = 0; i <= ticket.Count - 1; i++)
                ticketbyte[i] = (byte) ticket[i];

            aesAlg.IV = dr.ReadBytes(16);
            aesAlg.Key = new byte[32];
            aesAlg.Padding = PaddingMode.None;
            aesAlg.Mode = CipherMode.CBC;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            var msDecrypt = new MemoryStream(ticketbyte);
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            try
            {
                var bytes1 = Encoding.ASCII.GetBytes(_vector);
                var bytes2 = Encoding.ASCII.GetBytes(_salt);
                var buffer = Convert.FromBase64String(value);
                var count = 0;
                var instance = Activator.CreateInstance<T>();
                byte[] numArray;
                try
                {
                    var bytes3 = new PasswordDeriveBytes(password, bytes2, _hash, _iterations).GetBytes(_keySize / 8);
                    instance.Mode = CipherMode.CBC;
                    using (var decryptor = instance.CreateDecryptor(bytes3, bytes1))
                    {
                        using (var memoryStream = new MemoryStream(buffer))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                numArray = new byte[buffer.Length];
                                count = cryptoStream.Read(numArray, 0, numArray.Length);
                            }
                        }
                    }
                    instance.Clear();
                }
                finally
                {
                    if (instance != null)
                        instance.Dispose();
                }
                return Encoding.UTF8.GetString(numArray, 0, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return string.Empty;
            }
        }

        public static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            using (var decryptor = Aes.Create())
            {
                decryptor.Mode = CipherMode.CBC;
                decryptor.Padding = PaddingMode.None;
                decryptor.Key = Key;
                decryptor.IV = IV;


                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                        cs.Close();
                    }

                    gameTicket = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                }
            }
            return gameTicket;
        }
    }
}