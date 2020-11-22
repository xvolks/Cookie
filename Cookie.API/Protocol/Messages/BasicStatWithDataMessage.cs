using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicStatWithDataMessage : BasicStatMessage
    {
        public new const ushort ProtocolId = 6573;

        public override ushort MessageID => ProtocolId;

        public List<StatisticData> Datas { get; set; }
        public BasicStatWithDataMessage() { }

        public BasicStatWithDataMessage( List<StatisticData> Datas ){
            this.Datas = Datas;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Datas.Count);
			foreach (var x in Datas)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var DatasCount = reader.ReadShort();
            Datas = new List<StatisticData>();
            for (var i = 0; i < DatasCount; i++)
            {
                StatisticData objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Datas.Add(objectToAdd);
            }
        }
    }
}
