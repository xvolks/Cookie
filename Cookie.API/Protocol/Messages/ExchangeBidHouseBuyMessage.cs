using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseBuyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5804;

        public override ushort MessageID => ProtocolId;

        public uint Uid { get; set; }
        public uint Qty { get; set; }
        public ulong Price { get; set; }
        public ExchangeBidHouseBuyMessage() { }

        public ExchangeBidHouseBuyMessage( uint Uid, uint Qty, ulong Price ){
            this.Uid = Uid;
            this.Qty = Qty;
            this.Price = Price;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Uid);
            writer.WriteVarUhInt(Qty);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadVarUhInt();
            Qty = reader.ReadVarUhInt();
            Price = reader.ReadVarUhLong();
        }
    }
}
