using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicDateMessage : NetworkMessage
    {
        public const uint ProtocolId = 177;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Day = 0;
        public byte Month = 0;
        public short Year = 0;

        public BasicDateMessage()
        {
        }

        public BasicDateMessage(
            byte day,
            byte month,
            short year
        )
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Day);
            writer.WriteByte(Month);
            writer.WriteShort(Year);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Day = reader.ReadByte();
            Month = reader.ReadByte();
            Year = reader.ReadShort();
        }
    }
}