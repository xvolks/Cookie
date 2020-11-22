using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class StatisticDataBoolean : StatisticData
    {
        public new const ushort ProtocolId = 482;

        public override ushort TypeID => ProtocolId;

        public bool Value { get; set; }
        public StatisticDataBoolean() { }

        public StatisticDataBoolean( bool Value ){
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadBoolean();
        }
    }
}
