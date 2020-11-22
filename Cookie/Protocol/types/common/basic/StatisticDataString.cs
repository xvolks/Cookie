using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatisticDataString : StatisticData
    {
        public new const short ProtocolId = 487;
        public override short TypeId { get { return ProtocolId; } }

        public string Value;

        public StatisticDataString(): base()
        {
        }

        public StatisticDataString(
            string value
        ): base()
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