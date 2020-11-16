using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeShopStockMultiMovementUpdatedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6038;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItemToSell> ObjectInfoList;

        public ExchangeShopStockMultiMovementUpdatedMessage()
        {
        }

        public ExchangeShopStockMultiMovementUpdatedMessage(
            List<ObjectItemToSell> objectInfoList
        )
        {
            ObjectInfoList = objectInfoList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectInfoList.Count());
            foreach (var current in ObjectInfoList)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectInfoList = reader.ReadShort();
            ObjectInfoList = new List<ObjectItemToSell>();
            for (short i = 0; i < countObjectInfoList; i++)
            {
                ObjectItemToSell type = new ObjectItemToSell();
                type.Deserialize(reader);
                ObjectInfoList.Add(type);
            }
        }
    }
}