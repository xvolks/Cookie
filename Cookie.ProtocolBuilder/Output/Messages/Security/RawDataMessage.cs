namespace Cookie.API.Protocol.Network.Messages.Security
{
    using Utils.IO;

    public class RawDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6253;
        public override ushort MessageID => ProtocolId;
        public byte[] Content { get; set; }

        public RawDataMessage() { }

        public RawDataMessage(byte[] content)
        {
            Content = content;
        }

        public override void Serialize(IDataWriter writer)
        {
            var contentLength = Content.Length;
            writer.WriteVarInt(contentLength);
            for (var i = 0; i < contentLength; i++)
             writer.WriteByte(Content[i]);
        }
        public override void Deserialize(IDataReader reader)
        {
            var contentLength = reader.ReadVarInt();
            reader.ReadBytes(contentLength);
        }
    }
}
