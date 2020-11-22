using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildBulletinSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const uint ProtocolId = 6691;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildBulletinSetErrorMessage(): base()
        {
        }

        public GuildBulletinSetErrorMessage(
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