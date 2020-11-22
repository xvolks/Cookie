using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TrustCertificate : NetworkType
    {
        public const ushort ProtocolId = 377;

        public override ushort TypeID => ProtocolId;

        public int Id { get; set; }
        public string Hash { get; set; }
        public TrustCertificate() { }

        public TrustCertificate( int Id, string Hash ){
            this.Id = Id;
            this.Hash = Hash;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Id);
            writer.WriteUTF(Hash);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadInt();
            Hash = reader.ReadUTF();
        }
    }
}
