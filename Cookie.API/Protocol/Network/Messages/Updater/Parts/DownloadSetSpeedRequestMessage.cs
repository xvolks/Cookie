using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    public class DownloadSetSpeedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1512;

        public DownloadSetSpeedRequestMessage(byte downloadSpeed)
        {
            DownloadSpeed = downloadSpeed;
        }

        public DownloadSetSpeedRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte DownloadSpeed { get; set; }

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