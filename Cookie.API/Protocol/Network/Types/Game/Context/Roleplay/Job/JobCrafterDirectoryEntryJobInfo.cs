using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryJobInfo : NetworkType
    {
        public const ushort ProtocolId = 195;

        public JobCrafterDirectoryEntryJobInfo(byte jobId, byte jobLevel, bool free, byte minLevel)
        {
            JobId = jobId;
            JobLevel = jobLevel;
            Free = free;
            MinLevel = minLevel;
        }

        public JobCrafterDirectoryEntryJobInfo()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte JobId { get; set; }
        public byte JobLevel { get; set; }
        public bool Free { get; set; }
        public byte MinLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
            writer.WriteByte(JobLevel);
            writer.WriteBoolean(Free);
            writer.WriteByte(MinLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
            JobLevel = reader.ReadByte();
            Free = reader.ReadBoolean();
            MinLevel = reader.ReadByte();
        }
    }
}