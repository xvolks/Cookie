namespace Cookie.Core
{
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DofusClient Client { get; set; }

        public Account(string login, string password, DofusClient client)
        {
            Login = login;
            Password = password;

            Client = client;

            Character = new Character(Client);
        }

        public int Id { get; set; }
        public string Ticket { get; set; }
        public string Nickname { get; set; }
        public string SecretQuestion { get; set; }
        public double AccountCreation { get; set; }
        public byte CommunityId { get; set; }
        public double SubscriptionElapsedDuration { get; set; }
        public double SubscriptionEndDate { get; set; }

        public Character Character { get; set; }
    }
}
