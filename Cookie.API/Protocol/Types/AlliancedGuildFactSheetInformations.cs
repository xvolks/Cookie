using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AlliancedGuildFactSheetInformations : GuildInformations
    {
        public new const ushort ProtocolId = 422;

        public override ushort TypeID => ProtocolId;

        public BasicNamedAllianceInformations AllianceInfos { get; set; }
        public AlliancedGuildFactSheetInformations() { }

        public AlliancedGuildFactSheetInformations( BasicNamedAllianceInformations AllianceInfos ){
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
            AllianceInfos = new BasicNamedAllianceInformations();
            AllianceInfos.Deserialize(reader);
        }
    }
}
