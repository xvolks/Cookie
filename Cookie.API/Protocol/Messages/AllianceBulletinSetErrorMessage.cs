using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceBulletinSetErrorMessage : SocialNoticeSetErrorMessage
    {
        public new const ushort ProtocolId = 6692;

        public override ushort MessageID => ProtocolId;

        public AllianceBulletinSetErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
