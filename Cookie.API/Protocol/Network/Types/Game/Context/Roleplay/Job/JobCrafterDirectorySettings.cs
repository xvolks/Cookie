using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectorySettings : NetworkType
    {
        public const ushort ProtocolId = 97;

        public JobCrafterDirectorySettings(byte jobId, byte minLevel, bool free)
        {
            JobId = jobId;
            MinLevel = minLevel;
            Free = free;
        }

        public JobCrafterDirectorySettings()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte JobId { get; set; }
        public byte MinLevel { get; set; }
        public bool Free { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(JobId);
            writer.WriteByte(MinLevel);
            writer.WriteBoolean(Free);
        }

        public override void Deserialize(IDataReader reader)
        {
            JobId = reader.ReadByte();
            MinLevel = reader.ReadByte();
            Free = reader.ReadBoolean();
        }
    }
}