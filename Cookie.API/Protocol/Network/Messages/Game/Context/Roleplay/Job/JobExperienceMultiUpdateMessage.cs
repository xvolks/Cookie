using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobExperienceMultiUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5809;

        public JobExperienceMultiUpdateMessage(List<JobExperience> experiencesUpdate)
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public JobExperienceMultiUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<JobExperience> ExperiencesUpdate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ExperiencesUpdate.Count);
            for (var experiencesUpdateIndex = 0;
                experiencesUpdateIndex < ExperiencesUpdate.Count;
                experiencesUpdateIndex++)
            {
                var objectToSend = ExperiencesUpdate[experiencesUpdateIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var experiencesUpdateCount = reader.ReadUShort();
            ExperiencesUpdate = new List<JobExperience>();
            for (var experiencesUpdateIndex = 0;
                experiencesUpdateIndex < experiencesUpdateCount;
                experiencesUpdateIndex++)
            {
                var objectToAdd = new JobExperience();
                objectToAdd.Deserialize(reader);
                ExperiencesUpdate.Add(objectToAdd);
            }
        }
    }
}