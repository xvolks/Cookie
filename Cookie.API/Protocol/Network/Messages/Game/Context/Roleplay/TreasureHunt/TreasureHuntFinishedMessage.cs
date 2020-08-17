using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6483;

        public TreasureHuntFinishedMessage(byte questType)
        {
            QuestType = questType;
        }

        public TreasureHuntFinishedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte QuestType { get; set; }

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