using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
    {
        public new const short ProtocolId = 45;
        public override short TypeId { get { return ProtocolId; } }

        public bool Sex = false;

        public CharacterBaseInformations(): base()
        {
        }

        public CharacterBaseInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            bool sex
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed
        )
        {
            Sex = sex;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Sex = reader.ReadBoolean();
        }
    }
}