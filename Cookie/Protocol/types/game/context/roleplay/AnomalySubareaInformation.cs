using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AnomalySubareaInformation : NetworkType
    {
        public const short ProtocolId = 565;
        public override short TypeId { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public short RewardRate = 0;
        public bool HasAnomaly = false;
        public long AnomalyClosingTime = 0;

        public AnomalySubareaInformation()
        {
        }

        public AnomalySubareaInformation(
            short subAreaId,
            short rewardRate,
            bool hasAnomaly,
            long anomalyClosingTime
        )
        {
            SubAreaId = subAreaId;
            RewardRate = rewardRate;
            HasAnomaly = hasAnomaly;
            AnomalyClosingTime = anomalyClosingTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarShort(RewardRate);
            writer.WriteBoolean(HasAnomaly);
            writer.WriteVarLong(AnomalyClosingTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            RewardRate = reader.ReadVarShort();
            HasAnomaly = reader.ReadBoolean();
            AnomalyClosingTime = reader.ReadVarLong();
        }
    }
}