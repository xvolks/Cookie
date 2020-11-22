using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangePodsModifiedMessage : ExchangeObjectMessage
    {
        public new const uint ProtocolId = 6670;
        public override uint MessageID { get { return ProtocolId; } }

        public int CurrentWeight = 0;
        public int MaxWeight = 0;

        public ExchangePodsModifiedMessage(): base()
        {
        }

        public ExchangePodsModifiedMessage(
            bool remote,
            int currentWeight,
            int maxWeight
        ): base(
            remote
        )
        {
            CurrentWeight = currentWeight;
            MaxWeight = maxWeight;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(CurrentWeight);
            writer.WriteVarInt(MaxWeight);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CurrentWeight = reader.ReadVarInt();
            MaxWeight = reader.ReadVarInt();
        }
    }
}