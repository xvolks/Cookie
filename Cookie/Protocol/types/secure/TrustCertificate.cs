using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TrustCertificate : NetworkType
    {
        public const short ProtocolId = 377;
        public override short TypeId { get { return ProtocolId; } }

        public int Id_ = 0;
        public string Hash;

        public TrustCertificate()
        {
        }

        public TrustCertificate(
            int id_,
            string hash
        )
        {
            Id_ = id_;
            Hash = hash;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Id_);
            writer.WriteUTF(Hash);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadInt();
            Hash = reader.ReadUTF();
        }
    }
}