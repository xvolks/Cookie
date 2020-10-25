using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectsDeletedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6034;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> ObjectUID;

        public ObjectsDeletedMessage()
        {
        }

        public ObjectsDeletedMessage(
            List<int> objectUID
        )
        {
            ObjectUID = objectUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ObjectUID.Count());
            foreach (var current in ObjectUID)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjectUID = reader.ReadShort();
            ObjectUID = new List<int>();
            for (short i = 0; i < countObjectUID; i++)
            {
                ObjectUID.Add(reader.ReadVarInt());
            }
        }
    }
}