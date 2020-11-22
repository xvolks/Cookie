using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SocialNoticeMessage : NetworkMessage
    {
        public const uint ProtocolId = 6688;
        public override uint MessageID { get { return ProtocolId; } }

        public string Content;
        public int Timestamp = 0;
        public long MemberId = 0;
        public string MemberName;

        public SocialNoticeMessage()
        {
        }

        public SocialNoticeMessage(
            string content,
            int timestamp,
            long memberId,
            string memberName
        )
        {
            Content = content;
            Timestamp = timestamp;
            MemberId = memberId;
            MemberName = memberName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteVarLong(MemberId);
            writer.WriteUTF(MemberName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            MemberId = reader.ReadVarLong();
            MemberName = reader.ReadUTF();
        }
    }
}