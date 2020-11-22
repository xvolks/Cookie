using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AchievementObjective : NetworkType
    {
        public const short ProtocolId = 404;
        public override short TypeId { get { return ProtocolId; } }

        public int Id_ = 0;
        public short MaxValue = 0;

        public AchievementObjective()
        {
        }

        public AchievementObjective(
            int id_,
            short maxValue
        )
        {
            Id_ = id_;
            MaxValue = maxValue;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Id_);
            writer.WriteVarShort(MaxValue);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarInt();
            MaxValue = reader.ReadVarShort();
        }
    }
}