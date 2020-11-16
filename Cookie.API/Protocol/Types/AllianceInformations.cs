using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AllianceInformations : BasicNamedAllianceInformations
    {
        public new const ushort ProtocolId = 417;

        public override ushort TypeID => ProtocolId;

        public GuildEmblem AllianceEmblem { get; set; }
        public AllianceInformations() { }

        public AllianceInformations( GuildEmblem AllianceEmblem ){
            this.AllianceEmblem = AllianceEmblem;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }
    }
}
