using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeShopStockMultiMovementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6038;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItemToSell> ObjectInfoList { get; set; }
        public ExchangeShopStockMultiMovementUpdatedMessage() { }

        public ExchangeShopStockMultiMovementUpdatedMessage( List<ObjectItemToSell> ObjectInfoList ){
            this.ObjectInfoList = ObjectInfoList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectInfoList.Count);
			foreach (var x in ObjectInfoList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectInfoListCount = reader.ReadShort();
            ObjectInfoList = new List<ObjectItemToSell>();
            for (var i = 0; i < ObjectInfoListCount; i++)
            {
                var objectToAdd = new ObjectItemToSell();
                objectToAdd.Deserialize(reader);
                ObjectInfoList.Add(objectToAdd);
            }
        }
    }
}
