using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectDeletedMessage : NetworkMessage
    {
        public const uint ProtocolId = 3024;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;

        public ObjectDeletedMessage()
        {
        }

        public ObjectDeletedMessage(
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