using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildMotdMessage : SocialNoticeMessage
    {
        public new const uint ProtocolId = 6590;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildMotdMessage(): base()
        {
        }

        public GuildMotdMessage(
            string content,
            int timestamp,
            long memberId,
            string memberName
        ): base(
            content,
            timestamp,
            memberId,
            memberName
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