using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemGenericQuantityPrice : ObjectItemGenericQuantity
    {
        public new const short ProtocolId = 494;
        public override short TypeId { get { return ProtocolId; } }

        public long Price = 0;

        public ObjectItemGenericQuantityPrice(): base()
        {
        }

        public ObjectItemGenericQuantityPrice(
            short objectGID,
            int quantity,
            long price
        ): base(
            objectGID,
            quantity
        )
        {
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Price = reader.ReadVarLong();
        }
    }
}