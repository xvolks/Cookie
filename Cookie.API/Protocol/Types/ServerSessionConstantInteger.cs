using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ServerSessionConstantInteger : ServerSessionConstant
    {
        public new const ushort ProtocolId = 433;

        public override ushort TypeID => ProtocolId;

        public int Value { get; set; }
        public ServerSessionConstantInteger() { }

        public ServerSessionConstantInteger( int Value ){
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadInt();
        }
    }
}
