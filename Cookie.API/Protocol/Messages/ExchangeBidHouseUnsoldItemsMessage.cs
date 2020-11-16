using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6612;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItemGenericQuantity> Items { get; set; }
        public ExchangeBidHouseUnsoldItemsMessage() { }

        public ExchangeBidHouseUnsoldItemsMessage( List<ObjectItemGenericQuantity> Items ){
            this.Items = Items;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Items.Count);
			foreach (var x in Items)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ItemsCount = reader.ReadShort();
            Items = new List<ObjectItemGenericQuantity>();
            for (var i = 0; i < ItemsCount; i++)
            {
                var objectToAdd = new ObjectItemGenericQuantity();
                objectToAdd.Deserialize(reader);
                Items.Add(objectToAdd);
            }
        }
    }
}
