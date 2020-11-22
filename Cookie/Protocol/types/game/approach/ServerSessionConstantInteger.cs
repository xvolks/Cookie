using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ServerSessionConstantInteger : ServerSessionConstant
    {
        public new const short ProtocolId = 433;
        public override short TypeId { get { return ProtocolId; } }

        public int Value = 0;

        public ServerSessionConstantInteger(): base()
        {
        }

        public ServerSessionConstantInteger(
            short id_,
            int value
        ): base(
            id_
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}