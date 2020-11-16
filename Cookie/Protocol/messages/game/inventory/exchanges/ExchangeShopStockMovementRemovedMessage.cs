using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5907;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectId = 0;

        public ExchangeShopStockMovementRemovedMessage()
        {
        }

        public ExchangeShopStockMovementRemovedMessage(
            int objectId
        )
        {
            ObjectId = objectId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectId = reader.ReadVarInt();
        }
    }
}