using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const ushort ProtocolId = 6687;

        public override ushort MessageID => ProtocolId;

        public string Content { get; set; }
        public AllianceMotdSetRequestMessage() { }

        public AllianceMotdSetRequestMessage( string Content ){
            this.Content = Content;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
        }
    }
}
