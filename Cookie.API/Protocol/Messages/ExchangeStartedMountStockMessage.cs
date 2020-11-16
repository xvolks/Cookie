using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartedMountStockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5984;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItem> ObjectsInfos { get; set; }
        public ExchangeStartedMountStockMessage() { }

        public ExchangeStartedMountStockMessage( List<ObjectItem> ObjectsInfos ){
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
            ObjectsInfos = new List<ObjectItem>();
            for (var i = 0; i < ObjectsInfosCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}
