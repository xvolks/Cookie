namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Types.Game.Context.Roleplay.Job;
    using Utils.IO;

    public class JobExperienceUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5654;
        public override ushort MessageID => ProtocolId;
        public JobExperience ExperiencesUpdate { get; set; }

        public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
        {
            ExperiencesUpdate = experiencesUpdate;
        }

        public JobExperienceUpdateMessage() { }

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
