using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class StatisticDataShort : StatisticData
    {
        public new const ushort ProtocolId = 488;

        public override ushort TypeID => ProtocolId;

        public short Value { get; set; }
        public StatisticDataShort() { }

        public StatisticDataShort( short Value ){
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadShort();
        }
    }
}
