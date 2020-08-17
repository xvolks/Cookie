using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6037;

        public ExchangeShopStockMultiMovementRemovedMessage(List<uint> objectIdList)
        {
            ObjectIdList = objectIdList;
        }

        public ExchangeShopStockMultiMovementRemovedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<uint> ObjectIdList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectIdList.Count);
            for (var objectIdListIndex = 0; objectIdListIndex < ObjectIdList.Count; objectIdListIndex++)
                writer.WriteVarUhInt(ObjectIdList[objectIdListIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectIdListCount = reader.ReadUShort();
            ObjectIdList = new List<uint>();
            for (var objectIdListIndex = 0; objectIdListIndex < objectIdListCount; objectIdListIndex++)
                ObjectIdList.Add(reader.ReadVarUhInt());
        }
    }
}