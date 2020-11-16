using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class NamedPartyTeam : NetworkType
    {
        public const ushort ProtocolId = 469;

        public override ushort TypeID => ProtocolId;

        public sbyte TeamId { get; set; }
        public string PartyName { get; set; }
        public NamedPartyTeam() { }

        public NamedPartyTeam( sbyte TeamId, string PartyName ){
            this.TeamId = TeamId;
            this.PartyName = PartyName;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(TeamId);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            TeamId = reader.ReadSByte();
            PartyName = reader.ReadUTF();
        }
    }
}
