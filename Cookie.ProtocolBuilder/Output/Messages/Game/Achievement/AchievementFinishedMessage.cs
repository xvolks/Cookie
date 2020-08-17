namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Utils.IO;

    public class AchievementFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6208;
        public override ushort MessageID => ProtocolId;
        public ushort ObjectId { get; set; }
        public byte Finishedlevel { get; set; }

        public AchievementFinishedMessage(ushort objectId, byte finishedlevel)
        {
            ObjectId = objectId;
            Finishedlevel = finishedlevel;
        }

        public AchievementFinishedMessage() { }

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
