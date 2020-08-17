using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    public class AchievementRewardable : NetworkType
    {
        public const ushort ProtocolId = 412;

        public AchievementRewardable(ushort objectId, byte finishedlevel)
        {
            ObjectId = objectId;
            Finishedlevel = finishedlevel;
        }

        public AchievementRewardable()
        {
        }

        public override ushort TypeID => ProtocolId;
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