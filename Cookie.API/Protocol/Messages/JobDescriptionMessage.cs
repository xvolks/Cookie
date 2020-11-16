using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobDescriptionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5655;

        public override ushort MessageID => ProtocolId;

        public List<JobDescription> JobsDescription { get; set; }
        public JobDescriptionMessage() { }

        public JobDescriptionMessage( List<JobDescription> JobsDescription ){
            this.JobsDescription = JobsDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)JobsDescription.Count);
			foreach (var x in JobsDescription)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var JobsDescriptionCount = reader.ReadShort();
            JobsDescription = new List<JobDescription>();
            for (var i = 0; i < JobsDescriptionCount; i++)
            {
                var objectToAdd = new JobDescription();
                objectToAdd.Deserialize(reader);
                JobsDescription.Add(objectToAdd);
            }
        }
    }
}
