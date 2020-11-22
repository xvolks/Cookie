using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBuyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5774;

        public override ushort MessageID => ProtocolId;

        public uint ObjectToBuyId { get; set; }
        public uint Quantity { get; set; }
        public ExchangeBuyMessage() { }

        public ExchangeBuyMessage( uint ObjectToBuyId, uint Quantity ){
            this.ObjectToBuyId = ObjectToBuyId;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectToBuyId);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectToBuyId = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
