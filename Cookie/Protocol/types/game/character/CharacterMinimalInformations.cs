using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterMinimalInformations : CharacterBasicMinimalInformations
    {
        public new const short ProtocolId = 110;
        public override short TypeId { get { return ProtocolId; } }

        public short Level = 0;

        public CharacterMinimalInformations(): base()
        {
        }

        public CharacterMinimalInformations(
            long id_,
            string name,
            short level
        ): base(
            id_,
            name
        )
        {
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarShort();
        }
    }
}