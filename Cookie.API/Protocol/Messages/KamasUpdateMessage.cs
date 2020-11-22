using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class KamasUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5537;

        public override ushort MessageID => ProtocolId;

        public ulong KamasTotal { get; set; }
        public KamasUpdateMessage() { }

        public KamasUpdateMessage( ulong KamasTotal ){
            this.KamasTotal = KamasTotal;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(KamasTotal);
        }

        public override void Deserialize(IDataReader reader)
        {
            KamasTotal = reader.ReadVarUhLong();
        }
    }
}
