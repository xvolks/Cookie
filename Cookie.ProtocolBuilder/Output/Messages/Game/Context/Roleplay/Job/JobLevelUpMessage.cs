namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Types.Game.Context.Roleplay.Job;
    using Utils.IO;

    public class JobLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5656;
        public override ushort MessageID => ProtocolId;
        public byte NewLevel { get; set; }
        public JobDescription JobsDescription { get; set; }

        public JobLevelUpMessage(byte newLevel, JobDescription jobsDescription)
        {
            NewLevel = newLevel;
            JobsDescription = jobsDescription;
        }

        public JobLevelUpMessage() { }

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
