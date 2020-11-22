using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismSetSabotagedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6468;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public PrismSetSabotagedRequestMessage() { }

        public PrismSetSabotagedRequestMessage( ushort SubAreaId ){
            this.SubAreaId = SubAreaId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}
