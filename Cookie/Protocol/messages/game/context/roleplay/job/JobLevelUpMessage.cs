using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobLevelUpMessage : NetworkMessage
    {
        public const uint ProtocolId = 5656;
        public override uint MessageID { get { return ProtocolId; } }

        public byte NewLevel = 0;
        public JobDescription JobsDescription;

        public JobLevelUpMessage()
        {
        }

        public JobLevelUpMessage(
            byte newLevel,
            JobDescription jobsDescription
        )
        {
            NewLevel = newLevel;
            JobsDescription = jobsDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(NewLevel);
            JobsDescription.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            NewLevel = reader.ReadByte();
            JobsDescription = new JobDescription();
            JobsDescription.Deserialize(reader);
        }
    }
}