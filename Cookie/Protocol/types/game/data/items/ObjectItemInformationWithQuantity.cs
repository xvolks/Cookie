using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
    {
        public new const short ProtocolId = 387;
        public override short TypeId { get { return ProtocolId; } }

        public int Quantity = 0;

        public ObjectItemInformationWithQuantity(): base()
        {
        }

        public ObjectItemInformationWithQuantity(
            short objectGID,
            List<ObjectEffect> effects,
            int quantity
        ): base(
            objectGID,
            effects
        )
        {
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarInt();
        }
    }
}