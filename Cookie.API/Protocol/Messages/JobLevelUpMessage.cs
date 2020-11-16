using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5656;

        public override ushort MessageID => ProtocolId;

        public byte NewLevel { get; set; }
        public JobDescription JobsDescription { get; set; }
        public JobLevelUpMessage() { }

        public JobLevelUpMessage( byte NewLevel, JobDescription JobsDescription ){
            this.NewLevel = NewLevel;
            this.JobsDescription = JobsDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(NewLevel);
            JobsDescription.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            NewLevel = reader.ReadByte();
            JobsDescription = new JobDescription();
            JobsDescription.Deserialize(reader);
        }
    }
}
