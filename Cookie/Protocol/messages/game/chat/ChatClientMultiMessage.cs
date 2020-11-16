using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatClientMultiMessage : ChatAbstractClientMessage
    {
        public new const uint ProtocolId = 861;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Channel = 0;

        public ChatClientMultiMessage(): base()
        {
        }

        public ChatClientMultiMessage(
            string content,
            byte channel
        ): base(
            content
        )
        {
            Channel = channel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Channel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Channel = reader.ReadByte();
        }
    }
}