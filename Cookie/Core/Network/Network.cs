using System;
using System.Reflection;
using Cookie.API.Core;
using Cookie.API.Core.Network;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.API.Protocol;
using Cookie.API.Utils.Extensions;

namespace Cookie.Core.Network
{
    public class Network : SelfRunningTaskQueue, IDisposable, INetwork
    {
        public Network(IAccount account, IClient connection, MessageDispatcher dispatcher) : base(100)
        {
            Account = account;
            Connection = connection;
            Dispatcher = dispatcher;
            ConnectionType = ClientConnectionType.Disconnected;

            RegisterPacket<NetworkMessage>(HandleNetworkMessage, MessagePriority.VeryHigh);
        }

        public IAccount Account { get; set; }

        public void Dispose()
        {
            if (!Running)
                return;

            Connection?.Disconnect();

            Dispatcher?.Stop();

            Stop();
        }

        public IClient Connection { get; set; }

        public ClientConnectionType ConnectionType { get; set; }

        public event Action<IAccount, NetworkMessage> MessageReceived;
        public event Action<IAccount, NetworkMessage> MessageSent;

        public MessageDispatcher Dispatcher { get; set; }
        public bool ExpectedDisconnection { get; set; }

        public void RegisterPacket<T>(Action<IAccount, T> handler, MessagePriority priority) where T : Message
        {
            Dispatcher.RegisterMessageHandler(Assembly.GetExecutingAssembly().ToString(), typeof(T), handler,
                priority);
        }

        public void SendToServer(NetworkMessage message, bool direct = false)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            if (direct)
                Send(message, ListenerEntry.Server);
            else
                Send(message, ListenerEntry.Server | ListenerEntry.Local);
        }

        public void Disconnect()
        {
            ExpectedDisconnection = true;
            Dispose();
        }

        public override void Start()
        {
            if (Running)
                return;
            if (Dispatcher.Stopped)
                Dispatcher.Resume();
            base.Start();
        }

        public override void Stop()
        {
            if (!Running)
                return;

            Connection?.Disconnect();

            Dispatcher?.Stop();

            base.Stop();
        }

        public new void AddMessage(Action a)
        {
            base.AddMessage(a);
        }

        private void HandleNetworkMessage(IAccount client, NetworkMessage message)
        {
            if (message.From != ListenerEntry.Server)
            {
                client.LogPacket("Client", message.ToString(), message.MessageID.ToString());
                MessageSent?.Invoke(client, message);
            }
            else if (message.From == ListenerEntry.Server)
            {
                client.LogPacket("Server", message.ToString(), message.MessageID.ToString());
                MessageReceived?.Invoke(client, message);
            }
        }

        public void Send(Message message)
        {
            if (message == null)
                throw new ArgumentException(nameof(message));
            Dispatcher.Enqueue(message, this);
        }

        public void Send(NetworkMessage message, ListenerEntry dest)
        {
            if (message == null)
                throw new ArgumentException(nameof(message));
            message.Destinations = dest;
            message.From = ListenerEntry.Local;
            Dispatcher.Enqueue(message, Account);
        }

        public void SendLocal(Message message)
        {
            if (message == null)
                throw new ArgumentException(nameof(message));
            Dispatcher.Enqueue(message, this);
        }

        public void SendToServer(NetworkMessage message, int delay)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            CallDelayed(delay, () => SendToServer(message));
        }

        protected override void OnTick()
        {
            try
            {
                Dispatcher.ProcessDispatching(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            base.OnTick();
        }
    }
}