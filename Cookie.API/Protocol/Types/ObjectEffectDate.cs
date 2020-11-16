using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectDate : ObjectEffect
    {
        public new const ushort ProtocolId = 72;

        public override ushort TypeID => ProtocolId;

        public ushort Year { get; set; }
        public sbyte Month { get; set; }
        public sbyte Day { get; set; }
        public sbyte Hour { get; set; }
        public sbyte Minute { get; set; }
        public ObjectEffectDate() { }

        public ObjectEffectDate( ushort Year, sbyte Month, sbyte Day, sbyte Hour, sbyte Minute ){
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.Hour = Hour;
            this.Minute = Minute;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Year);
            writer.WriteSByte(Month);
            writer.WriteSByte(Day);
            writer.WriteSByte(Hour);
            writer.WriteSByte(Minute);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Year = reader.ReadVarUhShort();
            Month = reader.ReadSByte();
            Day = reader.ReadSByte();
            Hour = reader.ReadSByte();
            Minute = reader.ReadSByte();
        }
    }
}
