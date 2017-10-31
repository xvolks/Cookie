namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    using Types.Game.Context.Roleplay.Job;
    using System.Collections.Generic;
    using Utils.IO;

    public class JobDescriptionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5655;
        public override ushort MessageID => ProtocolId;
        public List<JobDescription> JobsDescription { get; set; }

        public JobDescriptionMessage(List<JobDescription> jobsDescription)
        {
            JobsDescription = jobsDescription;
        }

        public JobDescriptionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)JobsDescription.Count);
            for (var jobsDescriptionIndex = 0; jobsDescriptionIndex < JobsDescription.Count; jobsDescriptionIndex++)
            {
                var objectToSend = JobsDescription[jobsDescriptionIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobsDescriptionCount = reader.ReadUShort();
            JobsDescription = new List<JobDescription>();
            for (var jobsDescriptionIndex = 0; jobsDescriptionIndex < jobsDescriptionCount; jobsDescriptionIndex++)
            {
                var objectToAdd = new JobDescription();
                objectToAdd.Deserialize(reader);
                JobsDescription.Add(objectToAdd);
            }
        }

    }
}
