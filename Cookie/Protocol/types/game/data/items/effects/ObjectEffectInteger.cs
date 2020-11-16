using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectInteger : ObjectEffect
    {
        public new const short ProtocolId = 70;
        public override short TypeId { get { return ProtocolId; } }

        public int Value = 0;

        public ObjectEffectInteger(): base()
        {
        }

        public ObjectEffectInteger(
            short actionId,
            int value
        ): base(
            actionId
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadVarInt();
        }
    }
}