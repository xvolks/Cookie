using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
    {
        public new const short ProtocolId = 444;
        public override short TypeId { get { return ProtocolId; } }

        public BasicAllianceInformations Alliance;

        public CharacterMinimalAllianceInformations(): base()
        {
        }

        public CharacterMinimalAllianceInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            BasicGuildInformations guild,
            BasicAllianceInformations alliance
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed,
            guild
        )
        {
            Alliance = alliance;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}