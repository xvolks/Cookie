using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class JobExperience : NetworkType
    {
        public const short ProtocolId = 98;
        public override short TypeId { get { return ProtocolId; } }

        public byte JobId = 0;
        public byte JobLevel = 0;
        public long JobXP = 0;
        public long JobXpLevelFloor = 0;
        public long JobXpNextLevelFloor = 0;

        public JobExperience()
        {
        }

        public JobExperience(
            byte jobId,
            byte jobLevel,
            long jobXP,
            long jobXpLevelFloor,
            long jobXpNextLevelFloor
        )
        {
            JobId = jobId;
            JobLevel = jobLevel;
            JobXP = jobXP;
            JobXpLevelFloor = jobXpLevelFloor;
            JobXpNextLevelFloor = jobXpNextLevelFloor;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
            writer.WriteByte(JobLevel);
            writer.WriteVarLong(JobXP);
            writer.WriteVarLong(JobXpLevelFloor);
            writer.WriteVarLong(JobXpNextLevelFloor);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
            JobLevel = reader.ReadByte();
            JobXP = reader.ReadVarLong();
            JobXpLevelFloor = reader.ReadVarLong();
            JobXpNextLevelFloor = reader.ReadVarLong();
        }
    }
}