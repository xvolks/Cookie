using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Cookie.Utils.Cryptography
{
    public class Rsa
    {
        private const string MPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA9XpbSNEUoM6niz3XTESWJI3h3J+YseUIdEShxyp0nMfX8xUHUktKQFYV4Q3fVpdn1PxOaxKEA8SYGNAncuIal9ZGHqkbFcNF7CNp0MUFecQi5gGYpg4JPlC0onfmn6R2shSAl7M+UCVgFpICVrtXxocosjg0OP2gWFZU8AjKDo4JJPapvubjUgufCGNXEWynRkOclMBXpAw2IBAO6KjRdGBllPmJfYcSQqG9tp5nKdzkLgITSg8JtK2tp5wfbt5tBlCLcvC7CAp9t3JZImOO5kRwCn4Jd2RUMcPCd7s1JHqRXfOtuItz7xcOlqHtyLExvotfMwIDAQAB";

        public static sbyte[] Encrypt(sbyte[] helloConnectMessageKey, string accountName, string accountPassword, string salt)
        {
            var byteList = new List<byte>();
            var cryptoServiceProvider1 = DecodeX509PublicKey(Convert.FromBase64String("MIIBUzANBgkqhkiG9w0BAQEFAAOCAUAAMIIBOwKCATIAgucoka9J2PXcNdjcu6CuDmgteIMB+rih2UZJIuSoNT/0J/lEKL/W4UYbDA4U/6TDS0dkMhOpDsSCIDpO1gPG6+6JfhADRfIJItyHZflyXNUjWOBG4zuxc/L6wldgX24jKo+iCvlDTNUedE553lrfSU23Hwwzt3+doEfgkgAf0l4ZBez5Z/ldp9it2NH6/2/7spHm0Hsvt/YPrJ+EK8ly5fdLk9cvB4QIQel9SQ3JE8UQrxOAx2wrivc6P0gXp5Q6bHQoad1aUp81Ox77l5e8KBJXHzYhdeXaM91wnHTZNhuWmFS3snUHRCBpjDBCkZZ+CxPnKMtm2qJIi57RslALQVTykEZoAETKWpLBlSm92X/eXY2DdGf+a7vju9EigYbX0aXxQy2Ln2ZBWmUJyZE8B58CAwEAAQ=="));
            var cryptoServiceProvider2 = DecodeX509PublicKey(DecryptHelloConnectMessageKey(helloConnectMessageKey, cryptoServiceProvider1.ExportParameters(false)));
            var s = AdaptSalt(salt);
            byteList.AddRange(Encoding.UTF8.GetBytes(s));
            byteList.AddRange(new byte[32]);
            byteList.Add((byte)accountName.Length);
            byteList.AddRange(Encoding.UTF8.GetBytes(accountName));
            byteList.AddRange(Encoding.UTF8.GetBytes(accountPassword));
            var numArray1 = cryptoServiceProvider2.Encrypt(byteList.ToArray(), false);
            var numArray2 = new sbyte[numArray1.Length];
            Buffer.BlockCopy(numArray1, 0, numArray2, 0, numArray1.Length);
            return numArray2;
        }

        private static RSACryptoServiceProvider DecodeX509PublicKey(byte[] X509Key)
        {
            RSACryptoServiceProvider cryptoServiceProvider1 = (RSACryptoServiceProvider)null;
            byte[] secondArray = new byte[15] { (byte)48, (byte)13, (byte)6, (byte)9, (byte)42, (byte)134, (byte)72, (byte)134, (byte)247, (byte)13, (byte)1, (byte)1, (byte)1, (byte)5, (byte)0 };
            byte[] numArray1 = new byte[15];
            BinaryReader binaryReader = new BinaryReader((Stream)new MemoryStream(X509Key));
            try
            {
                switch (binaryReader.ReadUInt16())
                {
                    case 33072:
                        int num1 = (int)binaryReader.ReadByte();
                        break;
                    case 33328:
                        int num2 = (int)binaryReader.ReadInt16();
                        break;
                    default:
                        return (RSACryptoServiceProvider)null;
                }
                if (CompareByteArrays(binaryReader.ReadBytes(15), secondArray))
                {
                    switch (binaryReader.ReadUInt16())
                    {
                        case 33027:
                            int num3 = (int)binaryReader.ReadByte();
                            break;
                        case 33283:
                            int num4 = (int)binaryReader.ReadInt16();
                            break;
                        default:
                            goto label_9;
                    }
                    if ((int)binaryReader.ReadByte() == 0)
                    {
                        switch (binaryReader.ReadUInt16())
                        {
                            case 33072:
                                int num5 = (int)binaryReader.ReadByte();
                                break;
                            case 33328:
                                int num6 = (int)binaryReader.ReadInt16();
                                break;
                            default:
                                goto label_14;
                        }
                        ushort num7 = binaryReader.ReadUInt16();
                        byte num8 = 0;
                        byte num9;
                        switch (num7)
                        {
                            case 33026:
                                num9 = binaryReader.ReadByte();
                                break;
                            case 33282:
                                num8 = binaryReader.ReadByte();
                                num9 = binaryReader.ReadByte();
                                break;
                            default:
                                return (RSACryptoServiceProvider)null;
                        }
                        int int32 = BitConverter.ToInt32(new byte[4] { num9, num8, (byte)0, (byte)0 }, 0);
                        byte num10 = binaryReader.ReadByte();
                        binaryReader.BaseStream.Seek(-1L, SeekOrigin.Current);
                        if ((int)num10 == 0)
                        {
                            int num11 = (int)binaryReader.ReadByte();
                            --int32;
                        }
                        byte[] numArray2 = binaryReader.ReadBytes(int32);
                        if ((int)binaryReader.ReadByte() != 2)
                            return (RSACryptoServiceProvider)null;
                        int count = (int)binaryReader.ReadByte();
                        byte[] numArray3 = binaryReader.ReadBytes(count);
                        RSACryptoServiceProvider cryptoServiceProvider2 = new RSACryptoServiceProvider();
                        RSAParameters parameters = new RSAParameters() { Modulus = numArray2, Exponent = numArray3 };
                        cryptoServiceProvider2.ImportParameters(parameters);
                        cryptoServiceProvider1 = cryptoServiceProvider2;
                        goto label_26;
                    }
                    label_14:
                    return (RSACryptoServiceProvider)null;
                }
                label_9:
                return (RSACryptoServiceProvider)null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                cryptoServiceProvider1 = (RSACryptoServiceProvider)null;
                //int num = (int)MessageBox.Show(ex.Message, ex.Source);
            }
            finally
            {
                binaryReader.Close();
            }
            label_26:
            return cryptoServiceProvider1;
        }

        private static bool CompareByteArrays(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
                return false;
            int index = 0;
            foreach (int first in firstArray)
            {
                if (first != (int)secondArray[index])
                    return false;
                ++index;
            }
            return true;
        }

        private static byte[] DecryptHelloConnectMessageKey(sbyte[] helloConnectMessageKey, RSAParameters parameters)
        {
            var numArray = new byte[helloConnectMessageKey.Length];
            Buffer.BlockCopy((Array)helloConnectMessageKey, 0, (Array)numArray, 0, helloConnectMessageKey.Length);
            BigInteger modulus = new BigInteger(((IEnumerable<byte>)parameters.Modulus).Reverse<byte>().Concat<byte>((IEnumerable<byte>)new byte[1]).ToArray<byte>());
            BigInteger exponent = new BigInteger(((IEnumerable<byte>)parameters.Exponent).Reverse<byte>().Concat<byte>((IEnumerable<byte>)new byte[1]).ToArray<byte>());
            return ((IEnumerable<byte>)((IEnumerable<byte>)BigInteger.ModPow(new BigInteger(((IEnumerable<byte>)numArray).Reverse<byte>().Concat<byte>((IEnumerable<byte>)new byte[1]).ToArray<byte>()), exponent, modulus).ToByteArray()).Reverse<byte>().ToArray<byte>()).SkipWhile<byte>((Func<byte, bool>)(x => (uint)x > 0U)).Skip<byte>(1).ToArray<byte>();
        }

        private static string AdaptSalt(string salt)
        {
            if (salt.Length < 32)
            {
                while (salt.Length < 32)
                    salt += " ";
            }
            return salt;
        }
    }
}
