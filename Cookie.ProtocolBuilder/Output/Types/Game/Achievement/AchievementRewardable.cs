namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    using Utils.IO;

    public class AchievementRewardable : NetworkType
    {
        public const ushort ProtocolId = 412;
        public override ushort TypeID => ProtocolId;
        public ushort ObjectId { get; set; }
        public byte Finishedlevel { get; set; }

        public AchievementRewardable(ushort objectId, byte finishedlevel)
        {
            ObjectId = objectId;
            Finishedlevel = finishedlevel;
        }

        public AchievementRewardable() { }

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
