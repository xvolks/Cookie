using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const uint ProtocolId = 6591;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildMotdSetErrorMessage(): base()
        {
        }

        public GuildMotdSetErrorMessage(
            byte reason
        ): base(
            reason
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