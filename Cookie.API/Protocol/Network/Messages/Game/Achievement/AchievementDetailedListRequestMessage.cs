using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementDetailedListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6357;

        public AchievementDetailedListRequestMessage(ushort categoryId)
        {
            CategoryId = categoryId;
        }

        public AchievementDetailedListRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort CategoryId { get; set; }

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