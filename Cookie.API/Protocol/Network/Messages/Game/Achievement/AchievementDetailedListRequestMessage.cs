namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Utils.IO;

    public class AchievementDetailedListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6357;
        public override ushort MessageID => ProtocolId;
        public ushort CategoryId { get; set; }

        public AchievementDetailedListRequestMessage(ushort categoryId)
        {
            CategoryId = categoryId;
        }

        public AchievementDetailedListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CategoryId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CategoryId = reader.ReadVarUhShort();
        }

    }
}
