using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterBasicMinimalInformations : AbstractCharacterInformation
    {
        public new const ushort ProtocolId = 503;

        public override ushort TypeID => ProtocolId;

        public string Name { get; set; }
        public CharacterBasicMinimalInformations() { }

        public CharacterBasicMinimalInformations( string Name ){
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }
    }
}
