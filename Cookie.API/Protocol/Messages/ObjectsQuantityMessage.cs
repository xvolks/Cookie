using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectsQuantityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6206;

        public override ushort MessageID => ProtocolId;

        public List<ObjectItemQuantity> ObjectsUIDAndQty { get; set; }
        public ObjectsQuantityMessage() { }

        public ObjectsQuantityMessage( List<ObjectItemQuantity> ObjectsUIDAndQty ){
            this.ObjectsUIDAndQty = ObjectsUIDAndQty;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ObjectsUIDAndQty.Count);
			foreach (var x in ObjectsUIDAndQty)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectsUIDAndQtyCount = reader.ReadShort();
            ObjectsUIDAndQty = new List<ObjectItemQuantity>();
            for (var i = 0; i < ObjectsUIDAndQtyCount; i++)
            {
                var objectToAdd = new ObjectItemQuantity();
                objectToAdd.Deserialize(reader);
                ObjectsUIDAndQty.Add(objectToAdd);
            }
        }
    }
}
