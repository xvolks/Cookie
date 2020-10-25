using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectsQuantityMessage : NetworkMessage
    {
        public const uint ProtocolId = 6206;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItemQuantity> ObjectsUIDAndQty;

        public ObjectsQuantityMessage()
        {
        }

        public ObjectsQuantityMessage(
            List<ObjectItemQuantity> objectsUIDAndQty
        )
        {
            ObjectsUIDAndQty = objectsUIDAndQty;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectsUIDAndQty.Count());
            foreach (var current in ObjectsUIDAndQty)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectsUIDAndQty = reader.ReadShort();
            ObjectsUIDAndQty = new List<ObjectItemQuantity>();
            for (short i = 0; i < countObjectsUIDAndQty; i++)
            {
                ObjectItemQuantity type = new ObjectItemQuantity();
                type.Deserialize(reader);
                ObjectsUIDAndQty.Add(type);
            }
        }
    }
}