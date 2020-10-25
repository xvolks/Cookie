using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterExperienceGainMessage : NetworkMessage
    {
        public const uint ProtocolId = 6321;
        public override uint MessageID { get { return ProtocolId; } }

        public long ExperienceCharacter = 0;
        public long ExperienceMount = 0;
        public long ExperienceGuild = 0;
        public long ExperienceIncarnation = 0;

        public CharacterExperienceGainMessage()
        {
        }

        public CharacterExperienceGainMessage(
            long experienceCharacter,
            long experienceMount,
            long experienceGuild,
            long experienceIncarnation
        )
        {
            ExperienceCharacter = experienceCharacter;
            ExperienceMount = experienceMount;
            ExperienceGuild = experienceGuild;
            ExperienceIncarnation = experienceIncarnation;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(ExperienceCharacter);
            writer.WriteVarLong(ExperienceMount);
            writer.WriteVarLong(ExperienceGuild);
            writer.WriteVarLong(ExperienceIncarnation);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ExperienceCharacter = reader.ReadVarLong();
            ExperienceMount = reader.ReadVarLong();
            ExperienceGuild = reader.ReadVarLong();
            ExperienceIncarnation = reader.ReadVarLong();
        }
    }
}