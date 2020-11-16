using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
    {
        public new const uint ProtocolId = 6337;
        public override uint MessageID { get { return ProtocolId; } }

        public ExchangeBidHouseInListUpdatedMessage(): base()
        {
        }

        public ExchangeBidHouseInListUpdatedMessage(
            int itemUID,
            int objGenericId,
            List<ObjectEffect> effects,
            List<long> prices
        ): base(
            itemUID,
            objGenericId,
            effects,
            prices
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}