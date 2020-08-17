using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5752;

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(List<BidExchangerObjectInfo> itemTypeDescriptions)
        {
            ItemTypeDescriptions = itemTypeDescriptions;
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<BidExchangerObjectInfo> ItemTypeDescriptions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ItemTypeDescriptions.Count);
            for (var itemTypeDescriptionsIndex = 0;
                itemTypeDescriptionsIndex < ItemTypeDescriptions.Count;
                itemTypeDescriptionsIndex++)
            {
                var objectToSend = ItemTypeDescriptions[itemTypeDescriptionsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var itemTypeDescriptionsCount = reader.ReadUShort();
            ItemTypeDescriptions = new List<BidExchangerObjectInfo>();
            for (var itemTypeDescriptionsIndex = 0;
                itemTypeDescriptionsIndex < itemTypeDescriptionsCount;
                itemTypeDescriptionsIndex++)
            {
                var objectToAdd = new BidExchangerObjectInfo();
                objectToAdd.Deserialize(reader);
                ItemTypeDescriptions.Add(objectToAdd);
            }
        }
    }
}