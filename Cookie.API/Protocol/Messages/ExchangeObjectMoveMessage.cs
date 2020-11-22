using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectMoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5518;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public int Quantity { get; set; }
        public ExchangeObjectMoveMessage() { }

        public ExchangeObjectMoveMessage( uint ObjectUID, int Quantity ){
            this.ObjectUID = ObjectUID;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarInt();
        }
    }
}
