using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
    {
        public new const ushort ProtocolId = 6129;

        public ExchangeStartedWithPodsMessage(double firstCharacterId, uint firstCharacterCurrentWeight,
            uint firstCharacterMaxWeight, double secondCharacterId, uint secondCharacterCurrentWeight,
            uint secondCharacterMaxWeight)
        {
            FirstCharacterId = firstCharacterId;
            FirstCharacterCurrentWeight = firstCharacterCurrentWeight;
            FirstCharacterMaxWeight = firstCharacterMaxWeight;
            SecondCharacterId = secondCharacterId;
            SecondCharacterCurrentWeight = secondCharacterCurrentWeight;
            SecondCharacterMaxWeight = secondCharacterMaxWeight;
        }

        public ExchangeStartedWithPodsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double FirstCharacterId { get; set; }
        public uint FirstCharacterCurrentWeight { get; set; }
        public uint FirstCharacterMaxWeight { get; set; }
        public double SecondCharacterId { get; set; }
        public uint SecondCharacterCurrentWeight { get; set; }
        public uint SecondCharacterMaxWeight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(FirstCharacterId);
            writer.WriteVarUhInt(FirstCharacterCurrentWeight);
            writer.WriteVarUhInt(FirstCharacterMaxWeight);
            writer.WriteDouble(SecondCharacterId);
            writer.WriteVarUhInt(SecondCharacterCurrentWeight);
            writer.WriteVarUhInt(SecondCharacterMaxWeight);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstCharacterId = reader.ReadDouble();
            FirstCharacterCurrentWeight = reader.ReadVarUhInt();
            FirstCharacterMaxWeight = reader.ReadVarUhInt();
            SecondCharacterId = reader.ReadDouble();
            SecondCharacterCurrentWeight = reader.ReadVarUhInt();
            SecondCharacterMaxWeight = reader.ReadVarUhInt();
        }
    }
}