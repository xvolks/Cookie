using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6037;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> ObjectIdList;

        public ExchangeShopStockMultiMovementRemovedMessage()
        {
        }

        public ExchangeShopStockMultiMovementRemovedMessage(
            List<int> objectIdList
        )
        {
            ObjectIdList = objectIdList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectIdList.Count());
            foreach (var current in ObjectIdList)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectIdList = reader.ReadShort();
            ObjectIdList = new List<int>();
            for (short i = 0; i < countObjectIdList; i++)
            {
                ObjectIdList.Add(reader.ReadVarInt());
            }
        }
    }
}