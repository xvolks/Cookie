using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
    {
        public new const uint ProtocolId = 6687;
        public override uint MessageID { get { return ProtocolId; } }

        public string Content;

        public AllianceMotdSetRequestMessage(): base()
        {
        }

        public AllianceMotdSetRequestMessage(
            string content
        ): base()
        {
            Content = content;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Content = reader.ReadUTF();
        }
    }
}