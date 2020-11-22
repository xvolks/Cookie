using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServerSelectionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 40;

        public override ushort MessageID => ProtocolId;

        public ushort ServerId { get; set; }
        public ServerSelectionMessage() { }

        public ServerSelectionMessage( ushort ServerId ){
            this.ServerId = ServerId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ServerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ServerId = reader.ReadVarUhShort();
        }
    }
}
