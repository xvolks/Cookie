using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectsAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6033;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItem> Object { get; set; }
        public ObjectsAddedMessage() { }

        public ObjectsAddedMessage( List<ObjectItem> Object ){
            this.Object = Object;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Object.Count);
			foreach (var x in Object)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectCount = reader.ReadShort();
            Object = new List<ObjectItem>();
            for (var i = 0; i < ObjectCount; i++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Object.Add(objectToAdd);
            }
        }
    }
}
