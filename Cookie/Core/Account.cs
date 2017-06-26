using Cookie.API.Core;
using Cookie.API.Core.Frames;
using Cookie.Core.Frames;

namespace Cookie.Core
{
    public class Account : IAccount
    {
        public Account(string login, string password, IDofusClient client)
        {
            Login = login;
            Password = password;

            Character = new Character();

            LatencyFrame = new LatencyFrame();
        }

        public string Login { get; set; }
        public string Password { get; set; }

        public int Id { get; set; }
        public string Ticket { get; set; }
        public string Nickname { get; set; }
        public string SecretQuestion { get; set; }
        public double AccountCreation { get; set; }
        public byte CommunityId { get; set; }
        public double SubscriptionElapsedDuration { get; set; }
        public double SubscriptionEndDate { get; set; }

        public ICharacter Character { get; set; }

        public ILatencyFrame LatencyFrame { get; set; }
    }
}