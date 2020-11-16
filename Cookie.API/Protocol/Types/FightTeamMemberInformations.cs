using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamMemberInformations : NetworkType
    {
        public const ushort ProtocolId = 44;

        public override ushort TypeID => ProtocolId;

        public double Id { get; set; }
        public FightTeamMemberInformations() { }

        public FightTeamMemberInformations( double Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
        }
    }
}
