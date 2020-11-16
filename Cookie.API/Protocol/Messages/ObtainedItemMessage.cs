using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObtainedItemMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6519;

        public override ushort MessageID => ProtocolId;

        public ushort GenericId { get; set; }
        public uint BaseQuantity { get; set; }
        public ObtainedItemMessage() { }

        public ObtainedItemMessage( ushort GenericId, uint BaseQuantity ){
            this.GenericId = GenericId;
            this.BaseQuantity = BaseQuantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(GenericId);
            writer.WriteVarUhInt(BaseQuantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenericId = reader.ReadVarUhShort();
            BaseQuantity = reader.ReadVarUhInt();
        }
    }
}
