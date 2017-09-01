namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    using Utils.IO;

    public class JobCrafterDirectoryListEntry : NetworkType
    {
        public const ushort ProtocolId = 196;
        public override ushort TypeID => ProtocolId;
        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }

        public JobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo jobInfo)
        {
            PlayerInfo = playerInfo;
            JobInfo = jobInfo;
        }

        public JobCrafterDirectoryListEntry() { }

        public override void Serialize(IDataWriter writer)
        {
            PlayerInfo.Serialize(writer);
            JobInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            JobInfo = new JobCrafterDirectoryEntryJobInfo();
            JobInfo.Deserialize(reader);
        }

    }
}
