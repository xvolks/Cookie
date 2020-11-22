using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeShopStockStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5910;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItemToSell> ObjectsInfos { get; set; }
        public ExchangeShopStockStartedMessage() { }

        public ExchangeShopStockStartedMessage( List<ObjectItemToSell> ObjectsInfos ){
            this.ObjectsInfos = ObjectsInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectsInfos.Count);
			foreach (var x in ObjectsInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectsInfosCount = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemToSell>();
            for (var i = 0; i < ObjectsInfosCount; i++)
            {
                var objectToAdd = new ObjectItemToSell();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}
