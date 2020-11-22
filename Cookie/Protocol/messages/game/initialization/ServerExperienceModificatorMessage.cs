using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ServerExperienceModificatorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6237;
        public override uint MessageID { get { return ProtocolId; } }

        public short ExperiencePercent = 0;

        public ServerExperienceModificatorMessage()
        {
        }

        public ServerExperienceModificatorMessage(
            short experiencePercent
        )
        {
            ExperiencePercent = experiencePercent;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ExperiencePercent);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ExperiencePercent = reader.ReadVarShort();
        }
    }
}