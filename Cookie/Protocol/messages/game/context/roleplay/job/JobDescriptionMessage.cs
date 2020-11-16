using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobDescriptionMessage : NetworkMessage
    {
        public const uint ProtocolId = 5655;
        public override uint MessageID { get { return ProtocolId; } }

        public List<JobDescription> JobsDescription;

        public JobDescriptionMessage()
        {
        }

        public JobDescriptionMessage(
            List<JobDescription> jobsDescription
        )
        {
            JobsDescription = jobsDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)JobsDescription.Count());
            foreach (var current in JobsDescription)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countJobsDescription = reader.ReadShort();
            JobsDescription = new List<JobDescription>();
            for (short i = 0; i < countJobsDescription; i++)
            {
                JobDescription type = new JobDescription();
                type.Deserialize(reader);
                JobsDescription.Add(type);
            }
        }
    }
}