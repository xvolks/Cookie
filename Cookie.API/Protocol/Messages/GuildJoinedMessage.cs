using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildJoinedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5564;

        public override ushort MessageID => ProtocolId;

        public GuildInformations GuildInfo { get; set; }
        public uint MemberRights { get; set; }
        public GuildJoinedMessage() { }

        public GuildJoinedMessage( GuildInformations GuildInfo, uint MemberRights ){
            this.GuildInfo = GuildInfo;
            this.MemberRights = MemberRights;
        }

        public override void Serialize(IDataWriter writer)
        {
            GuildInfo.Serialize(writer);
            writer.WriteVarUhInt(MemberRights);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MemberRights = reader.ReadVarUhInt();
        }
    }
}
