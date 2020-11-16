using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 50;

        public override ushort MessageID => ProtocolId;

        public GameServerInformations Server { get; set; }
        public ServerStatusUpdateMessage() { }

        public ServerStatusUpdateMessage( GameServerInformations Server ){
            this.Server = Server;
        }

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
