using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ConsoleMessage : NetworkMessage
    {
        public const uint ProtocolId = 75;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Type = 0;
        public string Content;

        public ConsoleMessage()
        {
        }

        public ConsoleMessage(
            byte type,
            string content
        )
        {
            Type = type;
            Content = content;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            Content = reader.ReadUTF();
        }
    }
}