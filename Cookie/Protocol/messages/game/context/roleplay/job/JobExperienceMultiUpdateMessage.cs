using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobExperienceMultiUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5809;
        public override uint MessageID { get { return ProtocolId; } }

        public List<JobExperience> ExperiencesUpdate;

        public JobExperienceMultiUpdateMessage()
        {
        }

        public JobExperienceMultiUpdateMessage(
            List<JobExperience> experiencesUpdate
        )
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ExperiencesUpdate.Count());
            foreach (var current in ExperiencesUpdate)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countExperiencesUpdate = reader.ReadShort();
            ExperiencesUpdate = new List<JobExperience>();
            for (short i = 0; i < countExperiencesUpdate; i++)
            {
                JobExperience type = new JobExperience();
                type.Deserialize(reader);
                ExperiencesUpdate.Add(type);
            }
        }
    }
}