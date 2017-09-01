using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectDate : ObjectEffect
    {
        public new const ushort ProtocolId = 72;

        public ObjectEffectDate(ushort year, byte month, byte day, byte hour, byte minute)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
        }

        public ObjectEffectDate()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Year { get; set; }
        public byte Month { get; set; }
        public byte Day { get; set; }
        public byte Hour { get; set; }
        public byte Minute { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Year);
            writer.WriteByte(Month);
            writer.WriteByte(Day);
            writer.WriteByte(Hour);
            writer.WriteByte(Minute);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Year = reader.ReadVarUhShort();
            Month = reader.ReadByte();
            Day = reader.ReadByte();
            Hour = reader.ReadByte();
            Minute = reader.ReadByte();
        }
    }
}