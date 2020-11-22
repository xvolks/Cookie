using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockBuyRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5951;
        public override uint MessageID { get { return ProtocolId; } }

        public long ProposedPrice = 0;

        public PaddockBuyRequestMessage()
        {
        }

        public PaddockBuyRequestMessage(
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