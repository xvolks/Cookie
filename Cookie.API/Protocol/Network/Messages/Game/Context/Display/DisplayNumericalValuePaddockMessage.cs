using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Display
{
    public class DisplayNumericalValuePaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6563;

        public DisplayNumericalValuePaddockMessage(int rideId, int value, byte type)
        {
            RideId = rideId;
            Value = value;
            Type = type;
        }

        public DisplayNumericalValuePaddockMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int RideId { get; set; }
        public int Value { get; set; }
        public byte Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RideId);
            writer.WriteInt(Value);
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            RideId = reader.ReadInt();
            Value = reader.ReadInt();
            Type = reader.ReadByte();
        }
    }
}