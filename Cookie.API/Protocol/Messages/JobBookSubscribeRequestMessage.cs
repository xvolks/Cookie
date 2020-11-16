using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobBookSubscribeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6592;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> JobIds { get; set; }
        public JobBookSubscribeRequestMessage() { }

        public JobBookSubscribeRequestMessage( List<sbyte> JobIds ){
            this.JobIds = JobIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)JobIds.Count);
			foreach (var x in JobIds)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var JobIdsCount = reader.ReadShort();
            JobIds = new List<sbyte>();
            for (var i = 0; i < JobIdsCount; i++)
            {
                JobIds.Add(reader.ReadSByte());
            }
        }
    }
}
