using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectMinMax : ObjectEffect
    {
        public new const short ProtocolId = 82;
        public override short TypeId { get { return ProtocolId; } }

        public int Min = 0;
        public int Max = 0;

        public ObjectEffectMinMax(): base()
        {
        }

        public ObjectEffectMinMax(
            short actionId,
            int min,
            int max
        ): base(
            actionId
        )
        {
            Min = min;
            Max = max;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Min);
            writer.WriteVarInt(Max);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Min = reader.ReadVarInt();
            Max = reader.ReadVarInt();
        }
    }
}