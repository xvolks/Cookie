using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    public class SocialNoticeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6688;

        public SocialNoticeMessage(string content, int timestamp, ulong memberId, string memberName)
        {
            Content = content;
            Timestamp = timestamp;
            MemberId = memberId;
            MemberName = memberName;
        }

        public SocialNoticeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Content { get; set; }
        public int Timestamp { get; set; }
        public ulong MemberId { get; set; }
        public string MemberName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Content);
            writer.WriteInt(Timestamp);
            writer.WriteVarUhLong(MemberId);
            writer.WriteUTF(MemberName);
        }

        public override void Deserialize(IDataReader reader)
        {
            Content = reader.ReadUTF();
            Timestamp = reader.ReadInt();
            MemberId = reader.ReadVarUhLong();
            MemberName = reader.ReadUTF();
        }
    }
}