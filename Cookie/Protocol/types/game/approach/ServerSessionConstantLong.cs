using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ServerSessionConstantLong : ServerSessionConstant
    {
        public new const short ProtocolId = 429;
        public override short TypeId { get { return ProtocolId; } }

        public double Value = 0;

        public ServerSessionConstantLong(): base()
        {
        }

        public ServerSessionConstantLong(
            short id_,
            double value
        ): base(
            id_
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadDouble();
        }
    }
}