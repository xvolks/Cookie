namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Utils.IO;

    public class DownloadErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1513;
        public override ushort MessageID => ProtocolId;
        public byte ErrorId { get; set; }
        public string Message { get; set; }
        public string HelpUrl { get; set; }

        public DownloadErrorMessage(byte errorId, string message, string helpUrl)
        {
            ErrorId = errorId;
            Message = message;
            HelpUrl = helpUrl;
        }

        public DownloadErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ErrorId);
            writer.WriteUTF(Message);
            writer.WriteUTF(HelpUrl);
        }

        public override void Deserialize(IDataReader reader)
        {
            ErrorId = reader.ReadByte();
            Message = reader.ReadUTF();
            HelpUrl = reader.ReadUTF();
        }

    }
}
