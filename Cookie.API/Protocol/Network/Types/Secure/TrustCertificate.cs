using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Secure
{
    public class TrustCertificate : NetworkType
    {
        public const ushort ProtocolId = 377;

        public TrustCertificate(int objectId, string hash)
        {
            ObjectId = objectId;
            Hash = hash;
        }

        public TrustCertificate()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int ObjectId { get; set; }
        public string Hash { get; set; }

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