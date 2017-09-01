using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5653;

        public JobCrafterDirectoryRemoveMessage(byte jobId, ulong playerId)
        {
            JobId = jobId;
            PlayerId = playerId;
        }

        public JobCrafterDirectoryRemoveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte JobId { get; set; }
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
            PlayerId = reader.ReadVarUhLong();
        }
    }
}