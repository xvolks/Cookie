using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6037;

        public override ushort MessageID => ProtocolId;

        public List<int> ObjectIdList { get; set; }
        public ExchangeShopStockMultiMovementRemovedMessage() { }

        public ExchangeShopStockMultiMovementRemovedMessage( List<int> ObjectIdList ){
            this.ObjectIdList = ObjectIdList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectIdList.Count);
			foreach (var x in ObjectIdList)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectIdListCount = reader.ReadShort();
            ObjectIdList = new List<int>();
            for (var i = 0; i < ObjectIdListCount; i++)
            {
                ObjectIdList.Add(reader.ReadVarInt());
            }
        }
    }
}
