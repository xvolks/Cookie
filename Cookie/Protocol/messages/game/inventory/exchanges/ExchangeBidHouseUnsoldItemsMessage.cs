using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6612;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItemGenericQuantity> Items;

        public ExchangeBidHouseUnsoldItemsMessage()
        {
        }

        public ExchangeBidHouseUnsoldItemsMessage(
            List<ObjectItemGenericQuantity> items
        )
        {
            Items = items;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Items.Count());
            foreach (var current in Items)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countItems = reader.ReadShort();
            Items = new List<ObjectItemGenericQuantity>();
            for (short i = 0; i < countItems; i++)
            {
                ObjectItemGenericQuantity type = new ObjectItemGenericQuantity();
                type.Deserialize(reader);
                Items.Add(type);
            }
        }
    }
}