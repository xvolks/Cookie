using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobCrafterDirectorySettings : NetworkType
    {
        public const ushort ProtocolId = 97;

        public override ushort TypeID => ProtocolId;

        public sbyte JobId { get; set; }
        public byte MinLevel { get; set; }
        public bool Free { get; set; }
        public JobCrafterDirectorySettings() { }

        public JobCrafterDirectorySettings( sbyte JobId, byte MinLevel, bool Free ){
            this.JobId = JobId;
            this.MinLevel = MinLevel;
            this.Free = Free;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(JobId);
            writer.WriteByte(MinLevel);
            writer.WriteBoolean(Free);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadSByte();
            MinLevel = reader.ReadByte();
            Free = reader.ReadBoolean();
        }
    }
}
