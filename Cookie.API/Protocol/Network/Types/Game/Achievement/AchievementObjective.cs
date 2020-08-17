using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    public class AchievementObjective : NetworkType
    {
        public const ushort ProtocolId = 404;

        public AchievementObjective(uint objectId, ushort maxValue)
        {
            ObjectId = objectId;
            MaxValue = maxValue;
        }

        public AchievementObjective()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint ObjectId { get; set; }
        public ushort MaxValue { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectId);
            writer.WriteVarUhShort(MaxValue);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhInt();
            MaxValue = reader.ReadVarUhShort();
        }
    }
}