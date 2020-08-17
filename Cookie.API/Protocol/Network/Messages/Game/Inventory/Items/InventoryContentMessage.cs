using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class InventoryContentMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3016;

        public InventoryContentMessage(List<ObjectItem> objects, ulong kamas)
        {
            Objects = objects;
            Kamas = kamas;
        }

        public InventoryContentMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ObjectItem> Objects { get; set; }
        public ulong Kamas { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Objects.Count);
            for (var objectsIndex = 0; objectsIndex < Objects.Count; objectsIndex++)
            {
                var objectToSend = Objects[objectsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteVarUhLong(Kamas);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectsCount = reader.ReadUShort();
            Objects = new List<ObjectItem>();
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Objects.Add(objectToAdd);
            }
            Kamas = reader.ReadVarUhLong();
        }
    }
}