using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceMotdSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const uint ProtocolId = 6683;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceMotdSetErrorMessage(): base()
        {
        }

        public AllianceMotdSetErrorMessage(
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