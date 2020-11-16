using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
    {
        public new const ushort ProtocolId = 193;

        public override ushort TypeID => ProtocolId;

        public uint Grade { get; set; }
        public CharacterMinimalPlusLookAndGradeInformations() { }

        public CharacterMinimalPlusLookAndGradeInformations( uint Grade ){
            this.Grade = Grade;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Grade);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Grade = reader.ReadVarUhInt();
        }
    }
}
