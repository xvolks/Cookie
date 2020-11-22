using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHousePriceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5805;

        public override ushort MessageID => ProtocolId;

        public ushort GenId { get; set; }
        public ExchangeBidHousePriceMessage() { }

        public ExchangeBidHousePriceMessage( ushort GenId ){
            this.GenId = GenId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(GenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenId = reader.ReadVarUhShort();
        }
    }
}
