using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobLevelUpMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5656;

        public JobLevelUpMessage(byte newLevel, JobDescription jobsDescription)
        {
            NewLevel = newLevel;
            JobsDescription = jobsDescription;
        }

        public JobLevelUpMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte NewLevel { get; set; }
        public JobDescription JobsDescription { get; set; }

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