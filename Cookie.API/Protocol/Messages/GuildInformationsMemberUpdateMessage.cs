using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildInformationsMemberUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5597;

        public override ushort MessageID => ProtocolId;

        public GuildMember Member { get; set; }
        public GuildInformationsMemberUpdateMessage() { }

        public GuildInformationsMemberUpdateMessage( GuildMember Member ){
            this.Member = Member;
        }

        public override void Serialize(IDataWriter writer)
        {
            Member.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Member = new GuildMember();
            Member.Deserialize(reader);
        }
    }
}
