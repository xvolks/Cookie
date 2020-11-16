using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class StorageObjectsRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 6035;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> ObjectUIDList;

        public StorageObjectsRemoveMessage()
        {
        }

        public StorageObjectsRemoveMessage(
            List<int> objectUIDList
        )
        {
            ObjectUIDList = objectUIDList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectUIDList.Count());
            foreach (var current in ObjectUIDList)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectUIDList = reader.ReadShort();
            ObjectUIDList = new List<int>();
            for (short i = 0; i < countObjectUIDList; i++)
            {
                ObjectUIDList.Add(reader.ReadVarInt());
            }
        }
    }
}