using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ServerSessionConstantString : ServerSessionConstant
    {
        public new const short ProtocolId = 436;
        public override short TypeId { get { return ProtocolId; } }

        public string Value;

        public ServerSessionConstantString(): base()
        {
        }

        public ServerSessionConstantString(
            short id_,
            string value
        ): base(
            id_
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