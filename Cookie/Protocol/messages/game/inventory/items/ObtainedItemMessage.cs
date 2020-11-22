using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObtainedItemMessage : NetworkMessage
    {
        public const uint ProtocolId = 6519;
        public override uint MessageID { get { return ProtocolId; } }

        public short GenericId = 0;
        public int BaseQuantity = 0;

        public ObtainedItemMessage()
        {
        }

        public ObtainedItemMessage(
            short genericId,
            int baseQuantity
        )
        {
            GenericId = genericId;
            BaseQuantity = baseQuantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(GenericId);
            writer.WriteVarInt(BaseQuantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GenericId = reader.ReadVarShort();
            BaseQuantity = reader.ReadVarInt();
        }
    }
}