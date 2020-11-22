using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeShopStockMovementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5909;

        public override ushort MessageID => ProtocolId;

        public ObjectItemToSell ObjectInfo { get; set; }
        public ExchangeShopStockMovementUpdatedMessage() { }

        public ExchangeShopStockMovementUpdatedMessage( ObjectItemToSell ObjectInfo ){
            this.ObjectInfo = ObjectInfo;
        }

        public override void Serialize(IDataWriter writer)
        {
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectInfo = new ObjectItemToSell();
            ObjectInfo.Deserialize(reader);
        }
    }
}
