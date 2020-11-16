using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SocialNoticeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6688;

        public override ushort MessageID => ProtocolId;

        public string Content { get; set; }
        public int Timestamp { get; set; }
        public ulong MemberId { get; set; }
        public string MemberName { get; set; }
        public SocialNoticeMessage() { }

        public SocialNoticeMessage( string Content, int Timestamp, ulong MemberId, string MemberName ){
            this.Content = Content;
            this.Timestamp = Timestamp;
            this.MemberId = MemberId;
            this.MemberName = MemberName;
        }

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
