using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionGuild : HumanOption
    {
        public new const ushort ProtocolId = 409;

        public override ushort TypeID => ProtocolId;

        public GuildInformations GuildInformations { get; set; }
        public HumanOptionGuild() { }

        public HumanOptionGuild( GuildInformations GuildInformations ){
            this.GuildInformations = GuildInformations;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            GuildInformations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuildInformations = new GuildInformations();
            GuildInformations.Deserialize(reader);
        }
    }
}
