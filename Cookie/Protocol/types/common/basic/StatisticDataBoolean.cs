using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class StatisticDataBoolean : StatisticData
    {
        public new const short ProtocolId = 482;
        public override short TypeId { get { return ProtocolId; } }

        public bool Value = false;

        public StatisticDataBoolean(): base()
        {
        }

        public StatisticDataBoolean(
            bool value
        ): base()
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadBoolean();
        }
    }
}