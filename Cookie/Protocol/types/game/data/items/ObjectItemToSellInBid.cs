using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectItemToSellInBid : ObjectItemToSell
    {
        public new const short ProtocolId = 164;
        public override short TypeId { get { return ProtocolId; } }

        public int UnsoldDelay = 0;

        public ObjectItemToSellInBid(): base()
        {
        }

        public ObjectItemToSellInBid(
            short objectGID,
            List<ObjectEffect> effects,
            int objectUID,
            int quantity,
            long objectPrice,
            int unsoldDelay
        ): base(
            objectGID,
            effects,
            objectUID,
            quantity,
            objectPrice
        )
        {
            UnsoldDelay = unsoldDelay;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(UnsoldDelay);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            UnsoldDelay = reader.ReadInt();
        }
    }
}