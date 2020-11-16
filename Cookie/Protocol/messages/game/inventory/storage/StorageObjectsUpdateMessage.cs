using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class StorageObjectsUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6036;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItem> ObjectList;

        public StorageObjectsUpdateMessage()
        {
        }

        public StorageObjectsUpdateMessage(
            List<ObjectItem> objectList
        )
        {
            ObjectList = objectList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectList.Count());
            foreach (var current in ObjectList)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectList = reader.ReadShort();
            ObjectList = new List<ObjectItem>();
            for (short i = 0; i < countObjectList; i++)
            {
                ObjectItem type = new ObjectItem();
                type.Deserialize(reader);
                ObjectList.Add(type);
            }
        }
    }
}