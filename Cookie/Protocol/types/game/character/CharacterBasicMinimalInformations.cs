using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterBasicMinimalInformations : AbstractCharacterInformation
    {
        public new const short ProtocolId = 503;
        public override short TypeId { get { return ProtocolId; } }

        public string Name;

        public CharacterBasicMinimalInformations(): base()
        {
        }

        public CharacterBasicMinimalInformations(
            long id_,
            string name
        ): base(
            id_
        )
        {
            Name = name;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}