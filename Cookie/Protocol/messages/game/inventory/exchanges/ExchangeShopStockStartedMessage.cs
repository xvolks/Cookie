using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeShopStockStartedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5910;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItemToSell> ObjectsInfos;

        public ExchangeShopStockStartedMessage()
        {
        }

        public ExchangeShopStockStartedMessage(
            List<ObjectItemToSell> objectsInfos
        )
        {
            ObjectsInfos = objectsInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectsInfos.Count());
            foreach (var current in ObjectsInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectsInfos = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSell>();
            for (short i = 0; i < countObjectsInfos; i++)
            {
                ObjectItemToSell type = new ObjectItemToSell();
                type.Deserialize(reader);
                ObjectsInfos.Add(type);
            }
        }
    }
}