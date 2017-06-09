using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages.Security
{
    public class RawDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 6253;
        public override uint MessageID { get { return ProtocolId; } }

        public byte[] Content { get; set; }

        public RawDataMessage() { }

        public RawDataMessage(byte[] content)
        {
            Content = content;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            int contentLength = Content.Length;
            writer.WriteVarInt(contentLength);
            for (int i = 0; i < contentLength; i++)
            {
                writer.WriteByte(Content[i]);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            int contentLength = reader.ReadVarInt();
            reader.ReadBytes(contentLength);
        }

    }
}
