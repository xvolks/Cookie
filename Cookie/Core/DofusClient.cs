using Cookie.Handlers.Connection;
using Cookie.Handlers.Game.Achievement;
using Cookie.Handlers.Game.Alliance;
using Cookie.Handlers.Game.Almanach;
using Cookie.Handlers.Game.Approach;
using Cookie.Handlers.Game.Basic;
using Cookie.Handlers.Game.Character.Choice;
using Cookie.Handlers.Game.Character.Stats;
using Cookie.Handlers.Game.Chat;
using Cookie.Handlers.Game.Chat.Channel;
using Cookie.Handlers.Game.Chat.Community;
using Cookie.Handlers.Game.Context;
using Cookie.Handlers.Game.Context.Mount;
using Cookie.Handlers.Game.Context.Notification;
using Cookie.Handlers.Game.Context.Roleplay;
using Cookie.Handlers.Game.Context.Roleplay.Emote;
using Cookie.Handlers.Game.Context.Roleplay.Fight.Arena;
using Cookie.Handlers.Game.Context.Roleplay.Havenbag;
using Cookie.Handlers.Game.Context.Roleplay.Houses;
using Cookie.Handlers.Game.Context.Roleplay.Job;
using Cookie.Handlers.Game.Context.Roleplay.Quest;
using Cookie.Handlers.Game.Dare;
using Cookie.Handlers.Game.Friend;
using Cookie.Handlers.Game.Guild;
using Cookie.Handlers.Game.Idol;
using Cookie.Handlers.Game.Initialization;
using Cookie.Handlers.Game.Interactive;
using Cookie.Handlers.Game.Inventory.Items;
using Cookie.Handlers.Game.Inventory.Spells;
using Cookie.Handlers.Game.Prism;
using Cookie.Handlers.Game.Pvp;
using Cookie.Handlers.Game.Shortcut;
using Cookie.Handlers.Game.Startup;
using Cookie.Handlers.Handshake;
using Cookie.Handlers.Queues;
using Cookie.Handlers.Secure;
using Cookie.Handlers.Security;
using Cookie.Handlers.Server.Basic;
using Cookie.Handlers.Web.Ankabox;
using Cookie.IO;
using Cookie.Utils.Extensions;
using System;
using System.Linq;
using System.Net.Sockets;
using Cookie.Handlers.Game.Context.Roleplay.Fight;
using Cookie.Handlers.Game.Context.Roleplay.Paddock;
using Cookie.Handlers.Game.Inventory.Exchanges;
using Cookie.Handlers.Game.Finishmoves;
using Cookie.Handlers.Game.Context.Dungeon;
using Cookie.Handlers.Game.Inventory;
using Cookie.Handlers.Game.Chat.Smiley;
using Cookie.Handlers.Game.Context.Fight;
using Cookie.Handlers.Game.Context.Roleplay.Objects;
using Cookie.Handlers.Game.Context.Display;
using Cookie.Handlers.Game.Character.Creation;
using Cookie.Handlers.Game.Character.Deletion;
using Cookie.Handlers.Game.Character.Status;
using Cookie.Handlers.Game.Context.Roleplay.Party;
using Cookie.Handlers.Game.Context.Fight.Character;

namespace Cookie.Core
{
    public class DofusClient : Client
    {
        #region IPs / Ports
        public static readonly string[] DofusIPs = { "213.248.126.39", "213.248.126.40" };
        public static readonly short[] DofusPorts = { 5555, 443 };

        public static string RandomIP = DofusIPs.RandomElementOrDefault();
        public static short RandomPort = DofusPorts.RandomElementOrDefault();
        #endregion

        #region Private Properties
        MessagePart _currentMessage;
        readonly Dispatcher _dispatcher;
        readonly BigEndianReader _reader = new BigEndianReader();
        #endregion

        #region Public Properties
        public Account Account { get; set; }
        public bool Debug = false;
        #endregion

        #region Constructor
        public DofusClient(string Login, string Password) : base(RandomIP, RandomPort)
        {
            _dispatcher = new Dispatcher(this);

            Account = new Account(Login, Password, this);

            // Register Handlers
            Register(typeof(HandshakeHandlers));
            Register(typeof(QueuesHandlers));
            Register(typeof(SecurityHandlers));
            Register(typeof(ConnectionHandlers));
            Register(typeof(GameApproachHandlers));
            Register(typeof(GameBasicHandlers));
            Register(typeof(GameCharacterChoiceHandlers));
            Register(typeof(SecureHandlers));
            Register(typeof(GameContextNotificationHandlers));
            Register(typeof(GameInitializationHandlers));
            Register(typeof(GameContextMountHandlers));
            Register(typeof(GameInventoryItemsHandlers));
            Register(typeof(GameShortcutHandlers));
            Register(typeof(GameContextRoleplayHavenbagHandlers));
            Register(typeof(GameContextRoleplayEmoteHandlers));
            Register(typeof(GameContextRoleplayHandlers));
            Register(typeof(GameChatHandlers));
            Register(typeof(GameContextRoleplayJobHandlers));
            Register(typeof(GamePvpHandlers));
            Register(typeof(GameGuildHandlers));
            Register(typeof(GameDareHandlers));
            Register(typeof(GamePrismHandlers));
            Register(typeof(GameChatChannelHandlers));
            Register(typeof(GameChatCommunityHandlers));
            Register(typeof(GameInventorySpellsHandlers));
            Register(typeof(GameFriendHandlers));
            Register(typeof(GameAchievementHandlers));
            Register(typeof(GameAllianceHandlers));
            Register(typeof(GameContextRoleplayQuestHandlers));
            Register(typeof(GameCharacterStatsHandlers));
            Register(typeof(GameContextRoleplayFightArenaHandlers));
            Register(typeof(GameAlmanachHandlers));
            Register(typeof(GameIdolHandlers));
            Register(typeof(WebAnkaboxHandlers));
            Register(typeof(GameStartupHandlers));
            Register(typeof(GameContextRoleplayHousesHandlers));
            Register(typeof(GameContextHandlers));
            Register(typeof(ServerBasicHandlers));
            Register(typeof(GameInteractiveHandlers));
            Register(typeof(GameContextRoleplayFightHandlers));
            Register(typeof(GameInventoryExchangesHandlers));
            Register(typeof(GameContextRoleplayPaddockHandlers));
            Register(typeof(GameFinishmovesHandlers));
            Register(typeof(GameContextDungeonHandlers));
            Register(typeof(GameInventoryHandlers));
            Register(typeof(GameChatSmileyHandlers));
            Register(typeof(GameContextFightHandlers));
            Register(typeof(GameContextRoleplayObjectsHandlers));
            Register(typeof(GameContextDisplayHandlers));
            Register(typeof(GameCharacterCreationHandlers));
            Register(typeof(GameCharacterDeletionHandlers));
            Register(typeof(GameCharacterStatusHandlers));
            Register(typeof(GameContextRoleplayPartyHandlers));
            Register(typeof(GameContextFightCharacterHandlers));
        }
        #endregion

        #region Events
        protected override void DisconnectedEvent()
        {
            base.DisconnectedEvent();
            if (Account == null) return;
            Account.Character.Status = Utils.Enums.CharacterStatus.Disconnected;
            Logger.Log("Vous avez été déconnecté.", LogMessageType.Public);
            Account = null;
        }

        protected override void SocketAsyncEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            base.SocketAsyncEventArgs_Completed(sender, e);
        }

        protected override void ReceiveEvent_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (!IsConnected())
                return;
            _reader.Add(e.Buffer, e.Offset, e.BytesTransferred);
            while (_reader.BytesAvailable > 0)
            {
                if (_currentMessage == null)
                    _currentMessage = new MessagePart();
                if (_currentMessage.Build(_reader))
                {
                    var messageDataReader = new CustomDataReader(_currentMessage.Data);
                    NetworkMessage message = MessageReceiver.BuildMessage((uint)_currentMessage.MessageId, messageDataReader);
                    if (message == null)
                        return;
                    _dispatcher.Dispatch(message);
                    _currentMessage = null;
                }
                else
                {
                    break;
                }
            }
            base.ReceiveEvent_Completed(sender, e);
        }

        public static byte[] StringToByteArray(string hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        #endregion

        #region Methods

        public void Send(NetworkMessage msg)
        {
            if (!IsConnected())
                return;

            var writer = new CustomDataWriter();
            MessagePacking pack = new MessagePacking();
            pack.Pack(msg, writer);
            
            lock (Sender)
            {
                if (Debug)
                    Logger.Log($"Send: ({msg.MessageID}) - " + msg.ToString().Split('.').Last(), LogMessageType.Arena);
                Socket.Send(writer.Data);
            }
        }

        public void Register(Type type)
        {
            _dispatcher.RegisterFrame(type);
        }
        public void UnRegister(Type type)
        {
            _dispatcher.UnRegisterFrame(type);
        }
        
        #endregion
    }
}
