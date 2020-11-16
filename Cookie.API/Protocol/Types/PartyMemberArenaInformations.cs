using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyMemberArenaInformations : PartyMemberInformations
    {
        public new const ushort ProtocolId = 391;

        public override ushort TypeID => ProtocolId;

        public ushort Rank { get; set; }
        public PartyMemberArenaInformations() { }

        public PartyMemberArenaInformations( ushort Rank ){
            this.Rank = Rank;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Rank);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Rank = reader.ReadVarUhShort();
        }
    }
}
