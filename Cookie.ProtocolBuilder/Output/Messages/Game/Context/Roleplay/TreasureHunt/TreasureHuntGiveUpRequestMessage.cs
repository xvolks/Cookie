namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntGiveUpRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6487;
        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }

        public TreasureHuntGiveUpRequestMessage(byte questType)
        {
            QuestType = questType;
        }

        public TreasureHuntGiveUpRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
        }

    }
}
