using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseGuildedInformations : HouseInstanceInformations
    {
        public new const ushort ProtocolId = 512;

        public override ushort TypeID => ProtocolId;

        public GuildInformations GuildInfo { get; set; }
        public HouseGuildedInformations() { }

        public HouseGuildedInformations( GuildInformations GuildInfo ){
            this.GuildInfo = GuildInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}
