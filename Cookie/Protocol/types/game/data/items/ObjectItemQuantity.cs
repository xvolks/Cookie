using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemQuantity : Item
    {
        public new const short ProtocolId = 119;
        public override short TypeId { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public int Quantity = 0;

        public ObjectItemQuantity(): base()
        {
        }

        public ObjectItemQuantity(
            int objectUID,
            int quantity
        ): base()
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(ObjectUID);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectUID = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
        }
    }
}