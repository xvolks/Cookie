using System.IO;
using Cookie.API.Utils.Cryptography;

namespace Cookie.Utils.Configurations
{
    public class AccountConfiguration
    {
        // Fields
        private const string Pw = "c00k1eB0tPr0j3cT";


        // Constructor
        public AccountConfiguration(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Properties
        public string Username { get; }

        public string Password { get; }
        public string FilePath => $"{Username}.cookie";


        public void Save(BinaryWriter bw)
        {
            bw.Write(Username);
            bw.Write(AES.Encrypt(Password, Pw));
        }

        public static AccountConfiguration Load(BinaryReader br)
        {
            var username = br.ReadString();
            var password = AES.Decrypt(br.ReadString(), Pw);
            return new AccountConfiguration(username, password);
        }
    }
}