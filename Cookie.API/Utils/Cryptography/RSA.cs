using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Cookie.API.Utils.Cryptography
{
    public class Rsa
    {
        private const string MPublicKey =
                "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA9XpbSNEUoM6niz3XTESWJI3h3J+YseUIdEShxyp0nMfX8xUHUktKQFYV4Q3fVpdn1PxOaxKEA8SYGNAncuIal9ZGHqkbFcNF7CNp0MUFecQi5gGYpg4JPlC0onfmn6R2shSAl7M+UCVgFpICVrtXxocosjg0OP2gWFZU8AjKDo4JJPapvubjUgufCGNXEWynRkOclMBXpAw2IBAO6KjRdGBllPmJfYcSQqG9tp5nKdzkLgITSg8JtK2tp5wfbt5tBlCLcvC7CAp9t3JZImOO5kRwCn4Jd2RUMcPCd7s1JHqRXfOtuItz7xcOlqHtyLExvotfMwIDAQAB"
            ;

        public static List<sbyte> Encrypt(List<sbyte> helloConnectMessageKey, string accountName,
            string accountPassword,
            string salt)
        {
            var byteList = new List<byte>();
            var cryptoServiceProvider1 =
                DecodeX509PublicKey(Convert.FromBase64String(
                    "MIIBUzANBgkqhkiG9w0BAQEFAAOCAUAAMIIBOwKCATIAgucoka9J2PXcNdjcu6CuDmgteIMB+rih2UZJIuSoNT/0J/lEKL/W4UYbDA4U/6TDS0dkMhOpDsSCIDpO1gPG6+6JfhADRfIJItyHZflyXNUjWOBG4zuxc/L6wldgX24jKo+iCvlDTNUedE553lrfSU23Hwwzt3+doEfgkgAf0l4ZBez5Z/ldp9it2NH6/2/7spHm0Hsvt/YPrJ+EK8ly5fdLk9cvB4QIQel9SQ3JE8UQrxOAx2wrivc6P0gXp5Q6bHQoad1aUp81Ox77l5e8KBJXHzYhdeXaM91wnHTZNhuWmFS3snUHRCBpjDBCkZZ+CxPnKMtm2qJIi57RslALQVTykEZoAETKWpLBlSm92X/eXY2DdGf+a7vju9EigYbX0aXxQy2Ln2ZBWmUJyZE8B58CAwEAAQ=="));
            var cryptoServiceProvider2 = DecodeX509PublicKey(DecryptHelloConnectMessageKey(helloConnectMessageKey,
                cryptoServiceProvider1.ExportParameters(false)));
            var s = AdaptSalt(salt);
            byteList.AddRange(Encoding.UTF8.GetBytes(s));
            byteList.AddRange(new byte[32]);
            byteList.Add((byte) accountName.Length);
            byteList.AddRange(Encoding.UTF8.GetBytes(accountName));
            byteList.AddRange(Encoding.UTF8.GetBytes(accountPassword));
            var numArray1 = cryptoServiceProvider2.Encrypt(byteList.ToArray(), false);
            var numArray2 = new sbyte[numArray1.Length];
            Buffer.BlockCopy(numArray1, 0, numArray2, 0, numArray1.Length);
            return numArray2.ToList();
        }

        private static RSACryptoServiceProvider DecodeX509PublicKey(byte[] X509Key)
        {
            RSACryptoServiceProvider cryptoServiceProvider1 = null;
            var secondArray = new byte[15] {48, 13, 6, 9, 42, 134, 72, 134, 247, 13, 1, 1, 1, 5, 0};
            var numArray1 = new byte[15];
            var binaryReader = new BinaryReader(new MemoryStream(X509Key));
            try
            {
                switch (binaryReader.ReadUInt16())
                {
                    case 33072:
                        int num1 = binaryReader.ReadByte();
                        break;
                    case 33328:
                        int num2 = binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }
                if (CompareByteArrays(binaryReader.ReadBytes(15), secondArray))
                {
                    switch (binaryReader.ReadUInt16())
                    {
                        case 33027:
                            int num3 = binaryReader.ReadByte();
                            break;
                        case 33283:
                            int num4 = binaryReader.ReadInt16();
                            break;
                        default:
                            goto label_9;
                    }
                    if (binaryReader.ReadByte() == 0)
                    {
                        switch (binaryReader.ReadUInt16())
                        {
                            case 33072:
                                int num5 = binaryReader.ReadByte();
                                break;
                            case 33328:
                                int num6 = binaryReader.ReadInt16();
                                break;
                            default:
                                goto label_14;
                        }
                        var num7 = binaryReader.ReadUInt16();
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
                                return null;
                        }
                        var int32 = BitConverter.ToInt32(new byte[4] {num9, num8, 0, 0}, 0);
                        var num10 = binaryReader.ReadByte();
                        binaryReader.BaseStream.Seek(-1L, SeekOrigin.Current);
                        if (num10 == 0)
                        {
                            int num11 = binaryReader.ReadByte();
                            --int32;
                        }
                        var numArray2 = binaryReader.ReadBytes(int32);
                        if (binaryReader.ReadByte() != 2)
                            return null;
                        int count = binaryReader.ReadByte();
                        var numArray3 = binaryReader.ReadBytes(count);
                        var cryptoServiceProvider2 = new RSACryptoServiceProvider();
                        var parameters = new RSAParameters {Modulus = numArray2, Exponent = numArray3};
                        cryptoServiceProvider2.ImportParameters(parameters);
                        cryptoServiceProvider1 = cryptoServiceProvider2;
                        goto label_26;
                    }
                    label_14:
                    return null;
                }
                label_9:
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                cryptoServiceProvider1 = null;
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
            var index = 0;
            foreach (int first in firstArray)
            {
                if (first != secondArray[index])
                    return false;
                ++index;
            }
            return true;
        }

        private static byte[] DecryptHelloConnectMessageKey(List<sbyte> helloConnectMessageKey,
            RSAParameters parameters)
        {
            var numArray = new byte[helloConnectMessageKey.Count];
            Buffer.BlockCopy(helloConnectMessageKey.ToArray(), 0, numArray, 0, helloConnectMessageKey.Count);
            var modulus = new BigInteger(parameters.Modulus.Reverse().Concat(new byte[1]).ToArray());
            var exponent = new BigInteger(parameters.Exponent.Reverse().Concat(new byte[1]).ToArray());
            return BigInteger
                .ModPow(new BigInteger(numArray.Reverse().Concat(new byte[1]).ToArray()), exponent, modulus)
                .ToByteArray().Reverse().ToArray().SkipWhile(x => (uint) x > 0U).Skip(1).ToArray();
        }

        private static string AdaptSalt(string salt)
        {
            if (salt.Length < 32)
                while (salt.Length < 32)
                    salt += " ";
            return salt;
        }
    }
}