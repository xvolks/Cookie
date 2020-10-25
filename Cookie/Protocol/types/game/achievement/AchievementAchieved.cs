using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AchievementAchieved : NetworkType
    {
        public const short ProtocolId = 514;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;
        public long AchievedBy = 0;

        public AchievementAchieved()
        {
        }

        public AchievementAchieved(
            short id_,
            long achievedBy
        )
        {
            Id_ = id_;
            AchievedBy = achievedBy;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Id_);
            writer.WriteVarLong(AchievedBy);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarShort();
            AchievedBy = reader.ReadVarLong();
        }
    }
}