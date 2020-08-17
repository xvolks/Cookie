namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    using Utils.IO;

    public class KrosmasterTransferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6348;
        public override ushort MessageID => ProtocolId;
        public string Uid { get; set; }
        public byte Failure { get; set; }

        public KrosmasterTransferMessage(string uid, byte failure)
        {
            Uid = uid;
            Failure = failure;
        }

        public KrosmasterTransferMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Uid);
            writer.WriteByte(Failure);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadUTF();
            Failure = reader.ReadByte();
        }

    }
}
