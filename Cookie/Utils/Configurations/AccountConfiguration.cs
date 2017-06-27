using Cookie.API.Utils.Cryptography;
using System.IO;

namespace Cookie.Utils.Configurations
{
    public class AccountConfiguration
    {

        // Properties
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string FilePath => $"{Username}.cookie";


        // Fields
        private const string pw = "c00k1e";


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
            string username = br.ReadString();
            string password = AES.Decrypt(br.ReadString(), pw);
            return new AccountConfiguration(username, password);
        }

    }
}
