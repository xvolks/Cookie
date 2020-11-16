using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class StatisticDataByte : StatisticData
    {
        public new const ushort ProtocolId = 486;

        public override ushort TypeID => ProtocolId;

        public sbyte Value { get; set; }
        public StatisticDataByte() { }

        public StatisticDataByte( sbyte Value ){
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadSByte();
        }
    }
}
