using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectDuration : ObjectEffect
    {
        public new const short ProtocolId = 75;
        public override short TypeId { get { return ProtocolId; } }

        public short Days = 0;
        public byte Hours = 0;
        public byte Minutes = 0;

        public ObjectEffectDuration(): base()
        {
        }

        public ObjectEffectDuration(
            short actionId,
            short days,
            byte hours,
            byte minutes
        ): base(
            actionId
        )
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Days);
            writer.WriteByte(Hours);
            writer.WriteByte(Minutes);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Days = reader.ReadVarShort();
            Hours = reader.ReadByte();
            Minutes = reader.ReadByte();
        }
    }
}