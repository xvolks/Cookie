using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildMembershipMessage : GuildJoinedMessage
    {
        public new const uint ProtocolId = 5835;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildMembershipMessage(): base()
        {
        }

        public GuildMembershipMessage(
            GuildInformations guildInfo,
            int memberRights
        ): base(
            guildInfo,
            memberRights
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}