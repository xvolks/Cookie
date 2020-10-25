using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectsAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6033;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItem> Object_;

        public ObjectsAddedMessage()
        {
        }

        public ObjectsAddedMessage(
            List<ObjectItem> object_
        )
        {
            Object_ = object_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Object_.Count());
            foreach (var current in Object_)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObject_ = reader.ReadShort();
            Object_ = new List<ObjectItem>();
            for (short i = 0; i < countObject_; i++)
            {
                ObjectItem type = new ObjectItem();
                type.Deserialize(reader);
                Object_.Add(type);
            }
        }
    }
}