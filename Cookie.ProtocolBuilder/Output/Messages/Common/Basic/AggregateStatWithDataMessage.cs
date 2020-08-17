namespace Cookie.API.Protocol.Network.Messages.Common.Basic
{
    using Types.Common.Basic;
    using System.Collections.Generic;
    using Utils.IO;

    public class AggregateStatWithDataMessage : AggregateStatMessage
    {
        public new const ushort ProtocolId = 6662;
        public override ushort MessageID => ProtocolId;
        public List<StatisticData> Datas { get; set; }

        public AggregateStatWithDataMessage(List<StatisticData> datas)
        {
            Datas = datas;
        }

        public AggregateStatWithDataMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Datas.Count);
            for (var datasIndex = 0; datasIndex < Datas.Count; datasIndex++)
            {
                var objectToSend = Datas[datasIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var datasCount = reader.ReadUShort();
            Datas = new List<StatisticData>();
            for (var datasIndex = 0; datasIndex < datasCount; datasIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<StatisticData>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Datas.Add(objectToAdd);
            }
        }

    }
}
