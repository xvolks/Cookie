using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PortalUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6492;

        public override ushort MessageID => ProtocolId;

        public uint PortalId { get; set; }
        public PortalUseRequestMessage() { }

        public PortalUseRequestMessage( uint PortalId ){
            this.PortalId = PortalId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(PortalId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PortalId = reader.ReadVarUhInt();
        }
    }
}
