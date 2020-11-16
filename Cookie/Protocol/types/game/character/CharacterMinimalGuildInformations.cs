using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
    {
        public new const short ProtocolId = 445;
        public override short TypeId { get { return ProtocolId; } }

        public BasicGuildInformations Guild;

        public CharacterMinimalGuildInformations(): base()
        {
        }

        public CharacterMinimalGuildInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            BasicGuildInformations guild
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed
        )
        {
            Guild = guild;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }
    }
}