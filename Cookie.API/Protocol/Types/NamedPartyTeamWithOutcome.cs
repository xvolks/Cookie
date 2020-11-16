using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class NamedPartyTeamWithOutcome : NetworkType
    {
        public const ushort ProtocolId = 470;

        public override ushort TypeID => ProtocolId;

        public NamedPartyTeam Team { get; set; }
        public ushort Outcome { get; set; }
        public NamedPartyTeamWithOutcome() { }

        public NamedPartyTeamWithOutcome( NamedPartyTeam Team, ushort Outcome ){
            this.Team = Team;
            this.Outcome = Outcome;
        }

        public override void Serialize(IDataWriter writer)
        {
            Team.Serialize(writer);
            writer.WriteVarUhShort(Outcome);
        }

        public override void Deserialize(IDataReader reader)
        {
            Team = new NamedPartyTeam();
            Team.Deserialize(reader);
            Outcome = reader.ReadVarUhShort();
        }
    }
}
