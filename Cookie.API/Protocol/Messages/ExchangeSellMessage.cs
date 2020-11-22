using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeSellMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5778;

        public override ushort MessageID => ProtocolId;

        public uint ObjectToSellId { get; set; }
        public uint Quantity { get; set; }
        public ExchangeSellMessage() { }

        public ExchangeSellMessage( uint ObjectToSellId, uint Quantity ){
            this.ObjectToSellId = ObjectToSellId;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectToSellId);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectToSellId = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
