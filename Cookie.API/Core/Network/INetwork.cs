using System;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.API.Protocol;

namespace Cookie.API.Core.Network
{
    public interface INetwork
    {
        ClientConnectionType ConnectionType { get; set; }

        bool ExpectedDisconnection { get; set; }

        MessageDispatcher Dispatcher { get; set; }

        IClient Connection { get; set; }

        event Action<IAccount, NetworkMessage> MessageReceived;
        event Action<IAccount, NetworkMessage> MessageSent;

        void RegisterPacket<T>(Action<IAccount, T> handler, MessagePriority priority) where T : Message;

        void SendToServer(NetworkMessage message, bool direct = false);
        void Disconnect();

        void Start();
        void Stop();

        void AddMessage(Action a);

        void Dispose();
    }
}