namespace Cookie.API.Protocol.Network.Types.Secure
{
    using Utils.IO;

    public class TrustCertificate : NetworkType
    {
        public const ushort ProtocolId = 377;
        public override ushort TypeID => ProtocolId;
        public int ObjectId { get; set; }
        public string Hash { get; set; }

        public TrustCertificate(int objectId, string hash)
        {
            ObjectId = objectId;
            Hash = hash;
        }

        public TrustCertificate() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ObjectId);
            writer.WriteUTF(Hash);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadInt();
            Hash = reader.ReadUTF();
        }

    }
}
