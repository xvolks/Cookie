using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DisplayNumericalValuePaddockMessage : NetworkMessage
    {
        public const uint ProtocolId = 6563;
        public override uint MessageID { get { return ProtocolId; } }

        public int RideId = 0;
        public int Value = 0;
        public byte Type = 0;

        public DisplayNumericalValuePaddockMessage()
        {
        }

        public DisplayNumericalValuePaddockMessage(
            int rideId,
            int value,
            byte type
        )
        {
            RideId = rideId;
            Value = value;
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(RideId);
            writer.WriteInt(Value);
            writer.WriteByte(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RideId = reader.ReadInt();
            Value = reader.ReadInt();
            Type = reader.ReadByte();
        }
    }
}