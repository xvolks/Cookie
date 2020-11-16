using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterExperienceGainMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6321;

        public override ushort MessageID => ProtocolId;

        public ulong ExperienceCharacter { get; set; }
        public ulong ExperienceMount { get; set; }
        public ulong ExperienceGuild { get; set; }
        public ulong ExperienceIncarnation { get; set; }
        public CharacterExperienceGainMessage() { }

        public CharacterExperienceGainMessage( ulong ExperienceCharacter, ulong ExperienceMount, ulong ExperienceGuild, ulong ExperienceIncarnation ){
            this.ExperienceCharacter = ExperienceCharacter;
            this.ExperienceMount = ExperienceMount;
            this.ExperienceGuild = ExperienceGuild;
            this.ExperienceIncarnation = ExperienceIncarnation;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ExperienceCharacter);
            writer.WriteVarUhLong(ExperienceMount);
            writer.WriteVarUhLong(ExperienceGuild);
            writer.WriteVarUhLong(ExperienceIncarnation);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExperienceCharacter = reader.ReadVarUhLong();
            ExperienceMount = reader.ReadVarUhLong();
            ExperienceGuild = reader.ReadVarUhLong();
            ExperienceIncarnation = reader.ReadVarUhLong();
        }
    }
}
