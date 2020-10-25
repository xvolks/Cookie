using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemGenericQuantity : Item
    {
        public new const short ProtocolId = 483;
        public override short TypeId { get { return ProtocolId; } }

        public short ObjectGID = 0;
        public int Quantity = 0;

        public ObjectItemGenericQuantity(): base()
        {
        }

        public ObjectItemGenericQuantity(
            short objectGID,
            int quantity
        ): base()
        {
            ObjectGID = objectGID;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(ObjectGID);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarShort();
            Quantity = reader.ReadVarInt();
        }
    }
}