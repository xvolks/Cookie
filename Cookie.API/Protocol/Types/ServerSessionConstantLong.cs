using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ServerSessionConstantLong : ServerSessionConstant
    {
        public new const ushort ProtocolId = 429;

        public override ushort TypeID => ProtocolId;

        public double Value { get; set; }
        public ServerSessionConstantLong() { }

        public ServerSessionConstantLong( double Value ){
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadDouble();
        }
    }
}
