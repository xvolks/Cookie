using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
    {
        public const uint ProtocolId = 5752;
        public override uint MessageID { get { return ProtocolId; } }

        public List<BidExchangerObjectInfo> ItemTypeDescriptions;

        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }

        public ExchangeTypesItemsExchangerDescriptionForUserMessage(
            List<BidExchangerObjectInfo> itemTypeDescriptions
        )
        {
            ItemTypeDescriptions = itemTypeDescriptions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ItemTypeDescriptions.Count());
            foreach (var current in ItemTypeDescriptions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countItemTypeDescriptions = reader.ReadShort();
            ItemTypeDescriptions = new List<BidExchangerObjectInfo>();
            for (short i = 0; i < countItemTypeDescriptions; i++)
            {
                BidExchangerObjectInfo type = new BidExchangerObjectInfo();
                type.Deserialize(reader);
                ItemTypeDescriptions.Add(type);
            }
        }
    }
}