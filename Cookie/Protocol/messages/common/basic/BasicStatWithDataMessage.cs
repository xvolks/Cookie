using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicStatWithDataMessage : BasicStatMessage
    {
        public new const uint ProtocolId = 6573;
        public override uint MessageID { get { return ProtocolId; } }

        public List<StatisticData> Datas;

        public BasicStatWithDataMessage(): base()
        {
        }

        public BasicStatWithDataMessage(
            double timeSpent,
            short statId,
            List<StatisticData> datas
        ): base(
            timeSpent,
            statId
        )
        {
            Datas = datas;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Datas.Count());
            foreach (var current in Datas)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countDatas = reader.ReadShort();
            Datas = new List<StatisticData>();
            for (short i = 0; i < countDatas; i++)
            {
                var datastypeId = reader.ReadShort();
                StatisticData type = new StatisticData();
                type.Deserialize(reader);
                Datas.Add(type);
            }
        }
    }
}