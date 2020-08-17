using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectsDeletedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6034;

        public ObjectsDeletedMessage(List<uint> objectUID)
        {
            ObjectUID = objectUID;
        }

        public ObjectsDeletedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<uint> ObjectUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ObjectUID.Count);
            for (var objectUIDIndex = 0; objectUIDIndex < ObjectUID.Count; objectUIDIndex++)
                writer.WriteVarUhInt(ObjectUID[objectUIDIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var objectUIDCount = reader.ReadUShort();
            ObjectUID = new List<uint>();
            for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++)
                ObjectUID.Add(reader.ReadVarUhInt());
        }
    }
}