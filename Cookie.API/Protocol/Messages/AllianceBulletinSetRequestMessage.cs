using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceBulletinSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const ushort ProtocolId = 6693;

        public override ushort MessageID => ProtocolId;

        public string Content { get; set; }
        public bool NotifyMembers { get; set; }
        public AllianceBulletinSetRequestMessage() { }

        public AllianceBulletinSetRequestMessage( string Content, bool NotifyMembers ){
            this.Content = Content;
            this.NotifyMembers = NotifyMembers;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
            writer.WriteBoolean(NotifyMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
            NotifyMembers = reader.ReadBoolean();
        }
    }
}
