using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectSetPositionMessage : NetworkMessage
    {
        public const uint ProtocolId = 3021;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public short Position = 63;
        public int Quantity = 0;

        public ObjectSetPositionMessage()
        {
        }

        public ObjectSetPositionMessage(
            int objectUID,
            short position,
            int quantity
        )
        {
            ObjectUID = objectUID;
            Position = position;
            Quantity = quantity;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteShort(Position);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            Position = reader.ReadShort();
            Quantity = reader.ReadVarInt();
        }
    }
}