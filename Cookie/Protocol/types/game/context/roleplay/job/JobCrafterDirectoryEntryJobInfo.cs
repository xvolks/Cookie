using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class JobCrafterDirectoryEntryJobInfo : NetworkType
    {
        public const short ProtocolId = 195;
        public override short TypeId { get { return ProtocolId; } }

        public byte JobId = 0;
        public byte JobLevel = 0;
        public bool Free = false;
        public byte MinLevel = 0;

        public JobCrafterDirectoryEntryJobInfo()
        {
        }

        public JobCrafterDirectoryEntryJobInfo(
            byte jobId,
            byte jobLevel,
            bool free,
            byte minLevel
        )
        {
            JobId = jobId;
            JobLevel = jobLevel;
            Free = free;
            MinLevel = minLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
            writer.WriteByte(JobLevel);
            writer.WriteBoolean(Free);
            writer.WriteByte(MinLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
            JobLevel = reader.ReadByte();
            Free = reader.ReadBoolean();
            MinLevel = reader.ReadByte();
        }
    }
}