using Cookie.API.Core;
using Cookie.API.Core.Frames;
using Cookie.API.Core.Network;
using Cookie.API.Game.Achievement;
using Cookie.API.Game.Alliance;
using Cookie.API.Game.Chat;
using Cookie.API.Game.Friend;
using Cookie.API.Game.Guild;
using Cookie.API.Game.Inventory;
using Cookie.API.Game.Map;
using Cookie.API.Game.Party;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.Core.Frames;
using Cookie.Game.Achievement;
using Cookie.Game.Alliance;
using Cookie.Game.Chat;
using Cookie.Game.Friend;
using Cookie.Game.Guild;
using Cookie.Game.Inventory;
using Cookie.Game.Map;
using Cookie.Game.Party;

namespace Cookie.Core
{
    public class Account : IAccount
    {
        public Account(string login, string password, IClient connection, MessageDispatcher dispatcher, MainForm mainForm)
        {
            Login = login;
            Password = password;

            Network = new Network.Network(this, connection, dispatcher);

            MainForm = mainForm;

            Character = new Character(this);

            LatencyFrame = new LatencyFrame();

            BasicFrame = new BasicFrame(this);
            Achievement = new Achievement(this);
            Alliance = new Alliance(this);
            Chat = new Chat(this);
            Map = new Map(this);
            Friend = new Friend(this);
            Guild = new Guild(this);
            Inventory = new Inventory(this);
            Party = new Party(this);
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

        public IBasicFrame BasicFrame { get; set; }
        public IAchievement Achievement { get; set; }
        public IAlliance Alliance { get; set; }
        public IChat Chat { get; set; }
        public IMap Map { get; set; }
        public IFriend Friend { get; set; }
        public IGuild Guild { get; set; }
        public IInventory Inventory { get; set; }
        public IParty Party { get; set; }

        public INetwork Network { get; set; }
        

        public MainForm MainForm { get; set; }

        public void LogPacket(string origin, string name, string id) => MainForm.AddPacketsListView(origin, name, id);
        public void LogNoHandler(string name) => MainForm.AddNoHandlerPacket(name);
    }
}