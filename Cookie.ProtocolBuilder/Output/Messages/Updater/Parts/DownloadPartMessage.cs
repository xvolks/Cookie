namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Utils.IO;

    public class DownloadPartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1503;
        public override ushort MessageID => ProtocolId;
        public string ObjectId { get; set; }

        public DownloadPartMessage(string objectId)
        {
            ObjectId = objectId;
        }

        public DownloadPartMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadUTF();
        }

    }
}
