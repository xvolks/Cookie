using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockBuyResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6516;
        public override uint MessageID { get { return ProtocolId; } }

        public double PaddockId = 0;
        public bool Bought = false;
        public long RealPrice = 0;

        public PaddockBuyResultMessage()
        {
        }

        public PaddockBuyResultMessage(
            double paddockId,
            bool bought,
            long realPrice
        )
        {
            PaddockId = paddockId;
            Bought = bought;
            RealPrice = realPrice;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(PaddockId);
            writer.WriteBoolean(Bought);
            writer.WriteVarLong(RealPrice);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PaddockId = reader.ReadDouble();
            Bought = reader.ReadBoolean();
            RealPrice = reader.ReadVarLong();
        }
    }
}