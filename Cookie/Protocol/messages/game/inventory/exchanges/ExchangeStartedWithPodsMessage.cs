using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
    {
        public new const uint ProtocolId = 6129;
        public override uint MessageID { get { return ProtocolId; } }

        public double FirstCharacterId = 0;
        public int FirstCharacterCurrentWeight = 0;
        public int FirstCharacterMaxWeight = 0;
        public double SecondCharacterId = 0;
        public int SecondCharacterCurrentWeight = 0;
        public int SecondCharacterMaxWeight = 0;

        public ExchangeStartedWithPodsMessage(): base()
        {
        }

        public ExchangeStartedWithPodsMessage(
            byte exchangeType,
            double firstCharacterId,
            int firstCharacterCurrentWeight,
            int firstCharacterMaxWeight,
            double secondCharacterId,
            int secondCharacterCurrentWeight,
            int secondCharacterMaxWeight
        ): base(
            exchangeType
        )
        {
            FirstCharacterId = firstCharacterId;
            FirstCharacterCurrentWeight = firstCharacterCurrentWeight;
            FirstCharacterMaxWeight = firstCharacterMaxWeight;
            SecondCharacterId = secondCharacterId;
            SecondCharacterCurrentWeight = secondCharacterCurrentWeight;
            SecondCharacterMaxWeight = secondCharacterMaxWeight;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(FirstCharacterId);
            writer.WriteVarInt(FirstCharacterCurrentWeight);
            writer.WriteVarInt(FirstCharacterMaxWeight);
            writer.WriteDouble(SecondCharacterId);
            writer.WriteVarInt(SecondCharacterCurrentWeight);
            writer.WriteVarInt(SecondCharacterMaxWeight);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FirstCharacterId = reader.ReadDouble();
            FirstCharacterCurrentWeight = reader.ReadVarInt();
            FirstCharacterMaxWeight = reader.ReadVarInt();
            SecondCharacterId = reader.ReadDouble();
            SecondCharacterCurrentWeight = reader.ReadVarInt();
            SecondCharacterMaxWeight = reader.ReadVarInt();
        }
    }
}