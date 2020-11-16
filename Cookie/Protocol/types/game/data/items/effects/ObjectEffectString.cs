using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectString : ObjectEffect
    {
        public new const short ProtocolId = 74;
        public override short TypeId { get { return ProtocolId; } }

        public string Value;

        public ObjectEffectString(): base()
        {
        }

        public ObjectEffectString(
            short actionId,
            string value
        ): base(
            actionId
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadUTF();
        }
    }
}