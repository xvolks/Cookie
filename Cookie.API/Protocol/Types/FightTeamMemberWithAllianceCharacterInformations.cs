using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
    {
        public new const ushort ProtocolId = 426;

        public override ushort TypeID => ProtocolId;

        public BasicAllianceInformations AllianceInfos { get; set; }
        public FightTeamMemberWithAllianceCharacterInformations() { }

        public FightTeamMemberWithAllianceCharacterInformations( BasicAllianceInformations AllianceInfos ){
            this.AllianceInfos = AllianceInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInfos = new BasicAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}
