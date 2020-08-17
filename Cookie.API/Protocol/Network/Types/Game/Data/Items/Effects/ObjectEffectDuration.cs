using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectDuration : ObjectEffect
    {
        public new const ushort ProtocolId = 75;

        public ObjectEffectDuration(ushort days, byte hours, byte minutes)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public ObjectEffectDuration()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Days { get; set; }
        public byte Hours { get; set; }
        public byte Minutes { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Days);
            writer.WriteByte(Hours);
            writer.WriteByte(Minutes);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Days = reader.ReadVarUhShort();
            Hours = reader.ReadByte();
            Minutes = reader.ReadByte();
        }
    }
}