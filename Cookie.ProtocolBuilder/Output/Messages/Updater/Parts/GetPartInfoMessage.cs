namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Utils.IO;

    public class GetPartInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1506;
        public override ushort MessageID => ProtocolId;
        public string ObjectId { get; set; }

        public GetPartInfoMessage(string objectId)
        {
            ObjectId = objectId;
        }

        public GetPartInfoMessage() { }

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
