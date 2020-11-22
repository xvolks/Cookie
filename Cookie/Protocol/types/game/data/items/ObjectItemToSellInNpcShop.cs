using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
    {
        public new const short ProtocolId = 352;
        public override short TypeId { get { return ProtocolId; } }

        public long ObjectPrice = 0;
        public string BuyCriterion;

        public ObjectItemToSellInNpcShop(): base()
        {
        }

        public ObjectItemToSellInNpcShop(
            short objectGID,
            List<ObjectEffect> effects,
            long objectPrice,
            string buyCriterion
        ): base(
            objectGID,
            effects
        )
        {
            ObjectPrice = objectPrice;
            BuyCriterion = buyCriterion;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(ObjectPrice);
            writer.WriteUTF(BuyCriterion);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ObjectPrice = reader.ReadVarLong();
            BuyCriterion = reader.ReadUTF();
        }
    }
}