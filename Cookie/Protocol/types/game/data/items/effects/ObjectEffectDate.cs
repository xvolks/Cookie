using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectDate : ObjectEffect
    {
        public new const short ProtocolId = 72;
        public override short TypeId { get { return ProtocolId; } }

        public short Year = 0;
        public byte Month = 0;
        public byte Day = 0;
        public byte Hour = 0;
        public byte Minute = 0;

        public ObjectEffectDate(): base()
        {
        }

        public ObjectEffectDate(
            short actionId,
            short year,
            byte month,
            byte day,
            byte hour,
            byte minute
        ): base(
            actionId
        )
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Year);
            writer.WriteByte(Month);
            writer.WriteByte(Day);
            writer.WriteByte(Hour);
            writer.WriteByte(Minute);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Year = reader.ReadVarShort();
            Month = reader.ReadByte();
            Day = reader.ReadByte();
            Hour = reader.ReadByte();
            Minute = reader.ReadByte();
        }
    }
}