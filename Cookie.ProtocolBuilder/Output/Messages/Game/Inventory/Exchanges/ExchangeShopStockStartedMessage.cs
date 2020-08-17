namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeShopStockStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5910;
        public override ushort MessageID => ProtocolId;
        public List<ObjectItemToSell> ObjectsInfos { get; set; }

        public ExchangeShopStockStartedMessage(List<ObjectItemToSell> objectsInfos)
        {
            ObjectsInfos = objectsInfos;
        }

        public ExchangeShopStockStartedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ObjectsInfos.Count);
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count; objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new List<ObjectItemToSell>();
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemToSell();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }

    }
}
