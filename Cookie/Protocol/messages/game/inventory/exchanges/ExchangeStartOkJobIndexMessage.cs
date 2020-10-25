using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkJobIndexMessage : NetworkMessage
    {
        public const uint ProtocolId = 5819;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> Jobs;

        public ExchangeStartOkJobIndexMessage()
        {
        }

        public ExchangeStartOkJobIndexMessage(
            List<int> jobs
        )
        {
            Jobs = jobs;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Jobs.Count());
            foreach (var current in Jobs)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countJobs = reader.ReadShort();
            Jobs = new List<int>();
            for (short i = 0; i < countJobs; i++)
            {
                Jobs.Add(reader.ReadVarInt());
            }
        }
    }
}