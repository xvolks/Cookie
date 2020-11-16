using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobExperienceUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5654;
        public override uint MessageID { get { return ProtocolId; } }

        public JobExperience ExperiencesUpdate;

        public JobExperienceUpdateMessage()
        {
        }

        public JobExperienceUpdateMessage(
            JobExperience experiencesUpdate
        )
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            ExperiencesUpdate.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ExperiencesUpdate = new JobExperience();
            ExperiencesUpdate.Deserialize(reader);
        }
    }
}