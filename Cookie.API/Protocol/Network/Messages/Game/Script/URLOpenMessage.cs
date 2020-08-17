namespace Cookie.API.Protocol.Network.Messages.Game.Script
{
    using Utils.IO;

    public class URLOpenMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6266;
        public override ushort MessageID => ProtocolId;
        public byte UrlId { get; set; }

        public URLOpenMessage(byte urlId)
        {
            UrlId = urlId;
        }

        public URLOpenMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(UrlId);
        }

        public override void Deserialize(IDataReader reader)
        {
            UrlId = reader.ReadByte();
        }

    }
}
