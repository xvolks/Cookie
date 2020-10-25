using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
    {
        public new const short ProtocolId = 193;
        public override short TypeId { get { return ProtocolId; } }

        public int Grade = 0;

        public CharacterMinimalPlusLookAndGradeInformations(): base()
        {
        }

        public CharacterMinimalPlusLookAndGradeInformations(
            long id_,
            string name,
            short level,
            EntityLook entityLook_,
            byte breed,
            int grade
        ): base(
            id_,
            name,
            level,
            entityLook_,
            breed
        )
        {
            Grade = grade;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Grade);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadVarInt();
        }
    }
}