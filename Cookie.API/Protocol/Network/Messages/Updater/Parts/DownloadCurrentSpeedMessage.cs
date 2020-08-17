using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    public class DownloadCurrentSpeedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1511;

        public DownloadCurrentSpeedMessage(byte downloadSpeed)
        {
            DownloadSpeed = downloadSpeed;
        }

        public DownloadCurrentSpeedMessage()
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