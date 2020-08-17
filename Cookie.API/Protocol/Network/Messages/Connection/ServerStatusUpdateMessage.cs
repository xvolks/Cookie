using Cookie.API.Protocol.Network.Types.Connection;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class ServerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 50;

        public ServerStatusUpdateMessage(GameServerInformations server)
        {
            Server = server;
        }

        public ServerStatusUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public GameServerInformations Server { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Server.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Server = new GameServerInformations();
            Server.Deserialize(reader);
        }
    }
}