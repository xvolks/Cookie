using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceBulletinSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const uint ProtocolId = 6692;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceBulletinSetErrorMessage(): base()
        {
        }

        public AllianceBulletinSetErrorMessage(
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