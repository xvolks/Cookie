using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Storage
{
    public class StorageObjectsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6036;

        public StorageObjectsUpdateMessage(List<ObjectItem> objectList)
        {
            ObjectList = objectList;
        }

        public StorageObjectsUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ObjectItem> ObjectList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectList.Count);
            for (var objectListIndex = 0; objectListIndex < ObjectList.Count; objectListIndex++)
            {
                var objectToSend = ObjectList[objectListIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectListCount = reader.ReadUShort();
            ObjectList = new List<ObjectItem>();
            for (var objectListIndex = 0; objectListIndex < objectListCount; objectListIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ObjectList.Add(objectToAdd);
            }
        }
    }
}