using System.IO;
using Cookie.API.Utils.Cryptography;

namespace Cookie.Utils.Configurations
{
    public class AccountConfiguration
    {
        // Properties
        public string Username { get; }

        public string Password { get; }
        public string FilePath => $"{Username}.cookie";


        // Fields
        private const string pw = "c00k1eB0tPr0j3cT";


        // Constructor
        public AccountConfiguration(string username, string password)
        {
            Username = username;
            Password = password;
        }


        public void Save(BinaryWriter bw)
        {
            bw.Write(Username);
            bw.Write(AES.Encrypt(Password, pw));
        }

        public static AccountConfiguration Load(BinaryReader br)
        {
            var username = br.ReadString();
            var password = AES.Decrypt(br.ReadString(), pw);
            return new AccountConfiguration(username, password);
        }
    }
}
