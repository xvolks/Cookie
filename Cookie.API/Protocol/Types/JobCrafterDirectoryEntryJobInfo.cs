using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobCrafterDirectoryEntryJobInfo : NetworkType
    {
        public const ushort ProtocolId = 195;

        public override ushort TypeID => ProtocolId;

        public sbyte JobId { get; set; }
        public byte JobLevel { get; set; }
        public bool Free { get; set; }
        public byte MinLevel { get; set; }
        public JobCrafterDirectoryEntryJobInfo() { }

        public JobCrafterDirectoryEntryJobInfo( sbyte JobId, byte JobLevel, bool Free, byte MinLevel ){
            this.JobId = JobId;
            this.JobLevel = JobLevel;
            this.Free = Free;
            this.MinLevel = MinLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteByte(JobLevel);
            writer.WriteBoolean(Free);
            writer.WriteByte(MinLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            JobLevel = reader.ReadByte();
            Free = reader.ReadBoolean();
            MinLevel = reader.ReadByte();
        }
    }
}
