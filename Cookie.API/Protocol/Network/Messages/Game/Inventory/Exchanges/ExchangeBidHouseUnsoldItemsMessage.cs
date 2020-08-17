using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6612;

        public ExchangeBidHouseUnsoldItemsMessage(List<ObjectItemGenericQuantity> items)
        {
            Items = items;
        }

        public ExchangeBidHouseUnsoldItemsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ObjectItemGenericQuantity> Items { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Items.Count);
            for (var itemsIndex = 0; itemsIndex < Items.Count; itemsIndex++)
            {
                var objectToSend = Items[itemsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var itemsCount = reader.ReadUShort();
            Items = new List<ObjectItemGenericQuantity>();
            for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
            {
                var objectToAdd = new ObjectItemGenericQuantity();
                objectToAdd.Deserialize(reader);
                Items.Add(objectToAdd);
            }
        }
    }
}