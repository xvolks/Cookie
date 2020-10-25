using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatClientPrivateMessage : ChatAbstractClientMessage
    {
        public new const uint ProtocolId = 851;
        public override uint MessageID { get { return ProtocolId; } }

        public string Receiver;

        public ChatClientPrivateMessage(): base()
        {
        }

        public ChatClientPrivateMessage(
            string content,
            string receiver
        ): base(
            content
        )
        {
            Receiver = receiver;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Receiver);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Receiver = reader.ReadUTF();
        }
    }
}