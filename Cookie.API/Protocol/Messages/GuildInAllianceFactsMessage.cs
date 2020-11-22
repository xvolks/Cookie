using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInAllianceFactsMessage : GuildFactsMessage
    {
        public new const ushort ProtocolId = 6422;

        public override ushort MessageID => ProtocolId;

        public BasicNamedAllianceInformations AllianceInfos { get; set; }
        public GuildInAllianceFactsMessage() { }

        public GuildInAllianceFactsMessage( BasicNamedAllianceInformations AllianceInfos ){
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
