using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BulletinMessage : SocialNoticeMessage
    {
        public new const uint ProtocolId = 6695;
        public override uint MessageID { get { return ProtocolId; } }

        public int LastNotifiedTimestamp = 0;

        public BulletinMessage(): base()
        {
        }

        public BulletinMessage(
            string content,
            int timestamp,
            long memberId,
            string memberName,
            int lastNotifiedTimestamp
        ): base(
            content,
            timestamp,
            memberId,
            memberName
        )
        {
            LastNotifiedTimestamp = lastNotifiedTimestamp;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(LastNotifiedTimestamp);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LastNotifiedTimestamp = reader.ReadInt();
        }
    }
}