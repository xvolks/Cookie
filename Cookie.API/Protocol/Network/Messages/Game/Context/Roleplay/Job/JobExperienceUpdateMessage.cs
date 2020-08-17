using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobExperienceUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5654;

        public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public JobExperienceUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public JobExperience ExperiencesUpdate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            ExperiencesUpdate.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperiencesUpdate = new JobExperience();
            ExperiencesUpdate.Deserialize(reader);
        }
    }
}