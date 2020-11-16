using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectMovementMessage : NetworkMessage
    {
        public const uint ProtocolId = 3010;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public short Position = 63;

        public ObjectMovementMessage()
        {
        }

        public ObjectMovementMessage(
            int objectUID,
            short position
        )
        {
            ObjectUID = objectUID;
            Position = position;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteShort(Position);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            Position = reader.ReadShort();
        }
    }
}