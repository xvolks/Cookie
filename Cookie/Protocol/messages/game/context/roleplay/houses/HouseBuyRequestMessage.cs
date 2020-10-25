using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseBuyRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5738;
        public override uint MessageID { get { return ProtocolId; } }

        public long ProposedPrice = 0;

        public HouseBuyRequestMessage()
        {
        }

        public HouseBuyRequestMessage(
            long proposedPrice
        )
        {
            ProposedPrice = proposedPrice;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(ProposedPrice);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ProposedPrice = reader.ReadVarLong();
        }
    }
}