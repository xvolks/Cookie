using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5752;

        public override ushort MessageID => ProtocolId;

        public List<BidExchangerObjectInfo> ItemTypeDescriptions { get; set; }
        public ExchangeTypesItemsExchangerDescriptionForUserMessage() { }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage( List<BidExchangerObjectInfo> ItemTypeDescriptions ){
            this.ItemTypeDescriptions = ItemTypeDescriptions;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ItemTypeDescriptions.Count);
			foreach (var x in ItemTypeDescriptions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ItemTypeDescriptionsCount = reader.ReadShort();
            ItemTypeDescriptions = new List<BidExchangerObjectInfo>();
            for (var i = 0; i < ItemTypeDescriptionsCount; i++)
            {
                var objectToAdd = new BidExchangerObjectInfo();
                objectToAdd.Deserialize(reader);
                ItemTypeDescriptions.Add(objectToAdd);
            }
        }
    }
}
