using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeShopStockMultiMovementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6038;

        public ExchangeShopStockMultiMovementUpdatedMessage(List<ObjectItemToSell> objectInfoList)
        {
            ObjectInfoList = objectInfoList;
        }

        public ExchangeShopStockMultiMovementUpdatedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ObjectItemToSell> ObjectInfoList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectInfoList.Count);
            for (var objectInfoListIndex = 0; objectInfoListIndex < ObjectInfoList.Count; objectInfoListIndex++)
            {
                var objectToSend = ObjectInfoList[objectInfoListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectInfoListCount = reader.ReadUShort();
            ObjectInfoList = new List<ObjectItemToSell>();
            for (var objectInfoListIndex = 0; objectInfoListIndex < objectInfoListCount; objectInfoListIndex++)
            {
                var objectToAdd = new ObjectItemToSell();
                objectToAdd.Deserialize(reader);
                ObjectInfoList.Add(objectToAdd);
            }
        }
    }
}