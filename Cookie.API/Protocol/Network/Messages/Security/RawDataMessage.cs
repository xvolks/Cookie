using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Security
{
    public class RawDataMessage : NetworkMessage
    {
        public const uint ProtocolId = 6253;

        public RawDataMessage()
        {
        }

        public RawDataMessage(byte[] content)
        {
            Content = content;
        }

        public override uint MessageID => ProtocolId;

        public byte[] Content { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            var contentLength = Content.Length;
            writer.WriteVarInt(contentLength);
            for (var i = 0; i < contentLength; i++)
                writer.WriteByte(Content[i]);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var contentLength = reader.ReadVarInt();
            reader.ReadBytes(contentLength);
        }
    }
}