using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterMinimalGuildPublicInformations : CharacterMinimalInformations
    {
        public new const ushort ProtocolId = 556;

        public override ushort TypeID => ProtocolId;

        public uint Rank { get; set; }
        public CharacterMinimalGuildPublicInformations() { }

        public CharacterMinimalGuildPublicInformations( uint Rank ){
            this.Rank = Rank;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Rank);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarUhInt();
        }
    }
}
