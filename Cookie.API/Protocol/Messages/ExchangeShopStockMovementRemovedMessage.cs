using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5907;

        public override ushort MessageID => ProtocolId;

        public uint ObjectId { get; set; }
        public ExchangeShopStockMovementRemovedMessage() { }

        public ExchangeShopStockMovementRemovedMessage( uint ObjectId ){
            this.ObjectId = ObjectId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhInt();
        }
    }
}
