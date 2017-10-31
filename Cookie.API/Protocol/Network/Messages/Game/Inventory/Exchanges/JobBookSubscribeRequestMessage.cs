namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using Utils.IO;

    public class JobBookSubscribeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6592;
        public override ushort MessageID => ProtocolId;
        public List<byte> JobIds { get; set; }

        public JobBookSubscribeRequestMessage(List<byte> jobIds)
        {
            JobIds = jobIds;
        }

        public JobBookSubscribeRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)JobIds.Count);
            for (var jobIdsIndex = 0; jobIdsIndex < JobIds.Count; jobIdsIndex++)
            {
                writer.WriteByte(JobIds[jobIdsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var jobIdsCount = reader.ReadUShort();
            JobIds = new List<byte>();
            for (var jobIdsIndex = 0; jobIdsIndex < jobIdsCount; jobIdsIndex++)
            {
                JobIds.Add(reader.ReadByte());
            }
        }

    }
}
