using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BulletinMessage : SocialNoticeMessage
    {
        public new const ushort ProtocolId = 6695;

        public override ushort MessageID => ProtocolId;

        public int LastNotifiedTimestamp { get; set; }
        public BulletinMessage() { }

        public BulletinMessage( int LastNotifiedTimestamp ){
            this.LastNotifiedTimestamp = LastNotifiedTimestamp;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LastNotifiedTimestamp);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LastNotifiedTimestamp = reader.ReadInt();
        }
    }
}
