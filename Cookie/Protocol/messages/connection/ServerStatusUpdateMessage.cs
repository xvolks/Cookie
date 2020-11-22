using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ServerStatusUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 50;
        public override uint MessageID { get { return ProtocolId; } }

        public GameServerInformations Server;

        public ServerStatusUpdateMessage()
        {
        }

        public ServerStatusUpdateMessage(
            GameServerInformations server
        )
        {
            Server = server;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Server.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Server = new GameServerInformations();
            Server.Deserialize(reader);
        }
    }
}