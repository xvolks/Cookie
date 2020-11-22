using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicDateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 177;

        public override ushort MessageID => ProtocolId;

        public sbyte Day { get; set; }
        public sbyte Month { get; set; }
        public short Year { get; set; }
        public BasicDateMessage() { }

        public BasicDateMessage( sbyte Day, sbyte Month, short Year ){
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Day);
            writer.WriteSByte(Month);
            writer.WriteShort(Year);
        }

        public override void Deserialize(IDataReader reader)
        {
            Day = reader.ReadSByte();
            Month = reader.ReadSByte();
            Year = reader.ReadShort();
        }
    }
}
