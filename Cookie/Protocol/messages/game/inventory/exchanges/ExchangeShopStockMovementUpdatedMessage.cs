using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeShopStockMovementUpdatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5909;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItemToSell ObjectInfo;

        public ExchangeShopStockMovementUpdatedMessage()
        {
        }

        public ExchangeShopStockMovementUpdatedMessage(
            ObjectItemToSell objectInfo
        )
        {
            ObjectInfo = objectInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            ObjectInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectInfo = new ObjectItemToSell();
            ObjectInfo.Deserialize(reader);
        }
    }
}