using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkRecycleTradeMessage : NetworkMessage
    {
        public const uint ProtocolId = 6600;
        public override uint MessageID { get { return ProtocolId; } }

        public short PercentToPrism = 0;
        public short PercentToPlayer = 0;

        public ExchangeStartOkRecycleTradeMessage()
        {
        }

        public ExchangeStartOkRecycleTradeMessage(
            short percentToPrism,
            short percentToPlayer
        )
        {
            PercentToPrism = percentToPrism;
            PercentToPlayer = percentToPlayer;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(PercentToPrism);
            writer.WriteShort(PercentToPlayer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PercentToPrism = reader.ReadShort();
            PercentToPlayer = reader.ReadShort();
        }
    }
}