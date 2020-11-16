using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkNpcTradeMessage : NetworkMessage
    {
        public const uint ProtocolId = 5785;
        public override uint MessageID { get { return ProtocolId; } }

        public double NpcId = 0;

        public ExchangeStartOkNpcTradeMessage()
        {
        }

        public ExchangeStartOkNpcTradeMessage(
            double npcId
        )
        {
            NpcId = npcId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(NpcId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NpcId = reader.ReadDouble();
        }
    }
}