namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntFlagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6508;
        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }
        public byte Index { get; set; }

        public TreasureHuntFlagRequestMessage(byte questType, byte index)
        {
            QuestType = questType;
            Index = index;
        }

        public TreasureHuntFlagRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(QuestType);
            writer.WriteByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadByte();
            Index = reader.ReadByte();
        }

    }
}
