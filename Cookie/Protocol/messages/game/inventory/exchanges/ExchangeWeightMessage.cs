using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeWeightMessage : NetworkMessage
    {
        public const uint ProtocolId = 5793;
        public override uint MessageID { get { return ProtocolId; } }

        public int CurrentWeight = 0;
        public int MaxWeight = 0;

        public ExchangeWeightMessage()
        {
        }

        public ExchangeWeightMessage(
            int currentWeight,
            int maxWeight
        )
        {
            CurrentWeight = currentWeight;
            MaxWeight = maxWeight;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(CurrentWeight);
            writer.WriteVarInt(MaxWeight);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CurrentWeight = reader.ReadVarInt();
            MaxWeight = reader.ReadVarInt();
        }
    }
}