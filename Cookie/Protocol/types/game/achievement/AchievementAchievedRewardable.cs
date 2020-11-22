using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AchievementAchievedRewardable : AchievementAchieved
    {
        public new const short ProtocolId = 515;
        public override short TypeId { get { return ProtocolId; } }

        public short Finishedlevel = 0;

        public AchievementAchievedRewardable(): base()
        {
        }

        public AchievementAchievedRewardable(
            short id_,
            long achievedBy,
            short finishedlevel
        ): base(
            id_,
            achievedBy
        )
        {
            Finishedlevel = finishedlevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Finishedlevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Finishedlevel = reader.ReadVarShort();
        }
    }
}