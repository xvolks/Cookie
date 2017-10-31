namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Utils.IO;

    public class DownloadCurrentSpeedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1511;
        public override ushort MessageID => ProtocolId;
        public byte DownloadSpeed { get; set; }

        public DownloadCurrentSpeedMessage(byte downloadSpeed)
        {
            DownloadSpeed = downloadSpeed;
        }

        public DownloadCurrentSpeedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(DownloadSpeed);
        }

        public override void Deserialize(IDataReader reader)
        {
            DownloadSpeed = reader.ReadByte();
        }

    }
}
