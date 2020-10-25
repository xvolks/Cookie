using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PopupWarningMessage : NetworkMessage
    {
        public const uint ProtocolId = 6134;
        public override uint MessageID { get { return ProtocolId; } }

        public byte LockDuration = 0;
        public string Author;
        public string Content;

        public PopupWarningMessage()
        {
        }

        public PopupWarningMessage(
            byte lockDuration,
            string author,
            string content
        )
        {
            LockDuration = lockDuration;
            Author = author;
            Content = content;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(LockDuration);
            writer.WriteUTF(Author);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            LockDuration = reader.ReadByte();
            Author = reader.ReadUTF();
            Content = reader.ReadUTF();
        }
    }
}