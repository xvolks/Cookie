using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkJobIndexMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5819;

        public ExchangeStartOkJobIndexMessage(List<uint> jobs)
        {
            Jobs = jobs;
        }

        public ExchangeStartOkJobIndexMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<uint> Jobs { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Jobs.Count);
            for (var jobsIndex = 0; jobsIndex < Jobs.Count; jobsIndex++)
                writer.WriteVarUhInt(Jobs[jobsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobsCount = reader.ReadUShort();
            Jobs = new List<uint>();
            for (var jobsIndex = 0; jobsIndex < jobsCount; jobsIndex++)
                Jobs.Add(reader.ReadVarUhInt());
        }
    }
}