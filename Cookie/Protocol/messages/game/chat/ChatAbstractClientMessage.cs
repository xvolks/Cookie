using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatAbstractClientMessage : NetworkMessage
    {
        public const uint ProtocolId = 850;
        public override uint MessageID { get { return ProtocolId; } }

        public string Content;

        public ChatAbstractClientMessage()
        {
        }

        public ChatAbstractClientMessage(
            string content
        )
        {
            Content = content;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Content);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Content = reader.ReadUTF();
        }
    }
}