using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StorageObjectUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5647;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItem Object_;

        public StorageObjectUpdateMessage()
        {
        }

        public StorageObjectUpdateMessage(
            ObjectItem object_
        )
        {
            Object_ = object_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Object_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Object_ = new ObjectItem();
            Object_.Deserialize(reader);
        }
    }
}