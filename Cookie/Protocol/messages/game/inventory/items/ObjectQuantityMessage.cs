using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectQuantityMessage : NetworkMessage
    {
        public const uint ProtocolId = 3023;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public int Quantity = 0;
        public byte Origin = 0;

        public ObjectQuantityMessage()
        {
        }

        public ObjectQuantityMessage(
            int objectUID,
            int quantity,
            byte origin
        )
        {
            ObjectUID = objectUID;
            Quantity = quantity;
            Origin = origin;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteVarInt(Quantity);
            writer.WriteByte(Origin);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            Quantity = reader.ReadVarInt();
            Origin = reader.ReadByte();
        }
    }
}