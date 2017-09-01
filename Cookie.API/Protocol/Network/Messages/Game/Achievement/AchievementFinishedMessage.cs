using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6208;

        public AchievementFinishedMessage(ushort objectId, byte finishedlevel)
        {
            ObjectId = objectId;
            Finishedlevel = finishedlevel;
        }

        public AchievementFinishedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ObjectId { get; set; }
        public byte Finishedlevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
            writer.WriteByte(Finishedlevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
            Finishedlevel = reader.ReadByte();
        }
    }
}