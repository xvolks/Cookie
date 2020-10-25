using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedMountStockMessage : NetworkMessage
    {
        public const uint ProtocolId = 5984;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItem> ObjectsInfos;

        public ExchangeStartedMountStockMessage()
        {
        }

        public ExchangeStartedMountStockMessage(
            List<ObjectItem> objectsInfos
        )
        {
            ObjectsInfos = objectsInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectsInfos.Count());
            foreach (var current in ObjectsInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectsInfos = reader.ReadShort();
            ObjectsInfos = new List<ObjectItem>();
            for (short i = 0; i < countObjectsInfos; i++)
            {
                ObjectItem type = new ObjectItem();
                type.Deserialize(reader);
                ObjectsInfos.Add(type);
            }
        }
    }
}