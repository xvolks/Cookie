using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightAllianceTeamInformations : FightTeamInformations
    {
        public new const ushort ProtocolId = 439;

        public override ushort TypeID => ProtocolId;

        public sbyte Relation { get; set; }
        public FightAllianceTeamInformations() { }

        public FightAllianceTeamInformations( sbyte Relation ){
            this.Relation = Relation;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Relation);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Relation = reader.ReadSByte();
        }
    }
}
