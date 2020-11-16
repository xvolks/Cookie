using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseBuyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5738;

        public override ushort MessageID => ProtocolId;

        public ulong ProposedPrice { get; set; }
        public HouseBuyRequestMessage() { }

        public HouseBuyRequestMessage( ulong ProposedPrice ){
            this.ProposedPrice = ProposedPrice;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ProposedPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            ProposedPrice = reader.ReadVarUhLong();
        }
    }
}
