using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
    {
        public new const uint ProtocolId = 5884;
        public override uint MessageID { get { return ProtocolId; } }

        public HouseSellFromInsideRequestMessage(): base()
        {
        }

        public HouseSellFromInsideRequestMessage(
            int instanceId,
            long amount,
            bool forSale
        ): base(
            instanceId,
            amount,
            forSale
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