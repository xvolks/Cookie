using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
    {
        public new const ushort ProtocolId = 13;

        public override ushort TypeID => ProtocolId;

        public string Name { get; set; }
        public ushort Level { get; set; }
        public FightTeamMemberCharacterInformations() { }

        public FightTeamMemberCharacterInformations( string Name, ushort Level ){
            this.Name = Name;
            this.Level = Level;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarUhShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Level = reader.ReadVarUhShort();
        }
    }
}
