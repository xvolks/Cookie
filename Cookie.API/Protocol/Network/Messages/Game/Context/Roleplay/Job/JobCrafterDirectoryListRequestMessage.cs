using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6047;

        public JobCrafterDirectoryListRequestMessage(byte jobId)
        {
            JobId = jobId;
        }

        public JobCrafterDirectoryListRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte JobId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
        }
    }
}