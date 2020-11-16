using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildBulletinMessage : BulletinMessage
    {
        public new const uint ProtocolId = 6689;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildBulletinMessage(): base()
        {
        }

        public GuildBulletinMessage(
            string content,
            int timestamp,
            long memberId,
            string memberName,
            int lastNotifiedTimestamp
        ): base(
            content,
            timestamp,
            memberId,
            memberName,
            lastNotifiedTimestamp
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