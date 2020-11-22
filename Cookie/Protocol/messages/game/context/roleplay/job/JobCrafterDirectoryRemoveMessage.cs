using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectoryRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 5653;
        public override uint MessageID { get { return ProtocolId; } }

        public byte JobId = 0;
        public long PlayerId = 0;

        public JobCrafterDirectoryRemoveMessage()
        {
        }

        public JobCrafterDirectoryRemoveMessage(
            byte jobId,
            long playerId
        )
        {
            JobId = jobId;
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(JobId);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            JobId = reader.ReadByte();
            PlayerId = reader.ReadVarLong();
        }
    }
}