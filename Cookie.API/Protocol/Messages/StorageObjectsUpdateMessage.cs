using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StorageObjectsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6036;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItem> ObjectList { get; set; }
        public StorageObjectsUpdateMessage() { }

        public StorageObjectsUpdateMessage( List<ObjectItem> ObjectList ){
            this.ObjectList = ObjectList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectList.Count);
			foreach (var x in ObjectList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectListCount = reader.ReadShort();
            ObjectList = new List<ObjectItem>();
            for (var i = 0; i < ObjectListCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                ObjectList.Add(objectToAdd);
            }
        }
    }
}
