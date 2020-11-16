using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockGuildedInformations : PaddockBuyableInformations
    {
        public new const ushort ProtocolId = 508;

        public override ushort TypeID => ProtocolId;

        public bool Deserted { get; set; }
        public GuildInformations GuildInfo { get; set; }
        public PaddockGuildedInformations() { }

        public PaddockGuildedInformations( bool Deserted, GuildInformations GuildInfo ){
            this.Deserted = Deserted;
            this.GuildInfo = GuildInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Deserted);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Deserted = reader.ReadBoolean();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}
