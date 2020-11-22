using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class JobCrafterDirectorySettings : NetworkType
    {
        public const short ProtocolId = 97;
        public override short TypeId { get { return ProtocolId; } }

        public byte JobId = 0;
        public byte MinLevel = 0;
        public bool Free = false;

        public JobCrafterDirectorySettings()
        {
        }

        public JobCrafterDirectorySettings(
            byte jobId,
            byte minLevel,
            bool free
        )
        {
            JobId = jobId;
            MinLevel = minLevel;
            Free = free;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
            writer.WriteByte(MinLevel);
            writer.WriteBoolean(Free);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
            MinLevel = reader.ReadByte();
            Free = reader.ReadBoolean();
        }
    }
}