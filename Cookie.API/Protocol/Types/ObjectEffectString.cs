using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectString : ObjectEffect
    {
        public new const ushort ProtocolId = 74;

        public override ushort TypeID => ProtocolId;

        public string Value { get; set; }
        public ObjectEffectString() { }

        public ObjectEffectString( string Value ){
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadUTF();
        }
    }
}
