namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Utils.IO;

    public class DownloadSetSpeedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1512;
        public override ushort MessageID => ProtocolId;
        public byte DownloadSpeed { get; set; }

        public DownloadSetSpeedRequestMessage(byte downloadSpeed)
        {
            DownloadSpeed = downloadSpeed;
        }

        public DownloadSetSpeedRequestMessage() { }

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
