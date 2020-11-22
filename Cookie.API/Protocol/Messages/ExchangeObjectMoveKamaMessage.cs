using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectMoveKamaMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5520;

        public override ushort MessageID => ProtocolId;

        public long Quantity { get; set; }
        public ExchangeObjectMoveKamaMessage() { }

        public ExchangeObjectMoveKamaMessage( long Quantity ){
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            Quantity = reader.ReadVarLong();
        }
    }
}
