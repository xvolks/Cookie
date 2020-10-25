using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobBookSubscribeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6592;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> JobIds;

        public JobBookSubscribeRequestMessage()
        {
        }

        public JobBookSubscribeRequestMessage(
            List<byte> jobIds
        )
        {
            JobIds = jobIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)JobIds.Count());
            foreach (var current in JobIds)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countJobIds = reader.ReadShort();
            JobIds = new List<byte>();
            for (short i = 0; i < countJobIds; i++)
            {
                JobIds.Add(reader.ReadByte());
            }
        }
    }
}