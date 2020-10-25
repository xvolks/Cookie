using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StorageObjectRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 5648;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;

        public StorageObjectRemoveMessage()
        {
        }

        public StorageObjectRemoveMessage(
            int objectUID
        )
        {
            ObjectUID = objectUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
        }
    }
}