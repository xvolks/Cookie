namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class ObjectsQuantityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6206;
        public override ushort MessageID => ProtocolId;
        public List<ObjectItemQuantity> ObjectsUIDAndQty { get; set; }

        public ObjectsQuantityMessage(List<ObjectItemQuantity> objectsUIDAndQty)
        {
            ObjectsUIDAndQty = objectsUIDAndQty;
        }

        public ObjectsQuantityMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)ObjectsUIDAndQty.Count);
            for (var objectsUIDAndQtyIndex = 0; objectsUIDAndQtyIndex < ObjectsUIDAndQty.Count; objectsUIDAndQtyIndex++)
            {
                var objectToSend = ObjectsUIDAndQty[objectsUIDAndQtyIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsUIDAndQtyCount = reader.ReadUShort();
            ObjectsUIDAndQty = new List<ObjectItemQuantity>();
            for (var objectsUIDAndQtyIndex = 0; objectsUIDAndQtyIndex < objectsUIDAndQtyCount; objectsUIDAndQtyIndex++)
            {
                var objectToAdd = new ObjectItemQuantity();
                objectToAdd.Deserialize(reader);
                ObjectsUIDAndQty.Add(objectToAdd);
            }
        }

    }
}
