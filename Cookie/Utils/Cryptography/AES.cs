using Cookie.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DofusBot.Utils.Cryptography
{
    public static class AES
    {
        private static int _iterations;
        private static int _keySize;
        private static string _hash;
        private static string _salt;
        private static string _vector;
        private static string gameTicket;

        static AES()
        {
            AES._iterations = 2;
            AES._keySize = 256;
            AES._hash = "SHA1";
            AES._salt = "astr7ias38490a98";
            AES._vector = "8947az34zyl34kjq";
        }

        public static string Encrypt(string value, string password)
        {
            return AES.Encrypt<AesManaged>(value, password);
        }

        public static string Encrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            byte[] bytes1 = Encoding.ASCII.GetBytes(AES._vector);
            byte[] bytes2 = Encoding.ASCII.GetBytes(AES._salt);
            byte[] bytes3 = Encoding.UTF8.GetBytes(value);
            T instance = Activator.CreateInstance<T>();
            byte[] array;
            try
            {
                byte[] bytes4 = new PasswordDeriveBytes(password, bytes2, AES._hash, AES._iterations).GetBytes(AES._keySize / 8);
                instance.Mode = CipherMode.CBC;
                using (ICryptoTransform encryptor = instance.CreateEncryptor(bytes4, bytes1))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
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
                if ((object)instance != null)
                    instance.Dispose();
            }
            return Convert.ToBase64String(array);
        }

        public static string Decrypt(string value, string password)
        {
            return AES.Decrypt<AesManaged>(value, password);
        }

        public static string DecodeWithAES(List<int> ticket)
        {
            BigEndianReader dr = new BigEndianReader(new byte[32]);
            AesManaged aesAlg = new AesManaged();

            byte[] ticketbyte = new byte[ticket.Count];
            for (int i = 0; i <= ticket.Count - 1; i++)
            {
                ticketbyte[i] = (byte)ticket[i];
            }

            aesAlg.IV = dr.ReadBytes(16);
            aesAlg.Key = new byte[32];
            aesAlg.Padding = PaddingMode.None;
            aesAlg.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            MemoryStream msDecrypt = new MemoryStream(ticketbyte);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            StreamReader srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            try
            {
                byte[] bytes1 = Encoding.ASCII.GetBytes(AES._vector);
                byte[] bytes2 = Encoding.ASCII.GetBytes(AES._salt);
                byte[] buffer = Convert.FromBase64String(value);
                int count = 0;
                T instance = Activator.CreateInstance<T>();
                byte[] numArray;
                try
                {
                    byte[] bytes3 = new PasswordDeriveBytes(password, bytes2, AES._hash, AES._iterations).GetBytes(AES._keySize / 8);
                    instance.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = instance.CreateDecryptor(bytes3, bytes1))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(buffer))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
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
                    if ((object)instance != null)
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
            using (Aes decryptor = Aes.Create())
            {
                decryptor.Mode = CipherMode.CBC;
                decryptor.Padding = PaddingMode.None;
                decryptor.Key = Key;
                decryptor.IV = IV;


                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                        cs.Close();
                    }

                    gameTicket = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                }
            }
            return gameTicket;
        }
    }
}
