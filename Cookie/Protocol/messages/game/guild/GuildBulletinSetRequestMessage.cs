using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildBulletinSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const uint ProtocolId = 6694;
        public override uint MessageID { get { return ProtocolId; } }

        public string Content;
        public bool NotifyMembers = false;

        public GuildBulletinSetRequestMessage(): base()
        {
        }

        public GuildBulletinSetRequestMessage(
            string content,
            bool notifyMembers
        ): base()
        {
            Content = content;
            NotifyMembers = notifyMembers;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
            writer.WriteBoolean(NotifyMembers);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
            NotifyMembers = reader.ReadBoolean();
        }
    }
}