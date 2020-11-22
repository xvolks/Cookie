using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class JobCrafterDirectoryListEntry : NetworkType
    {
        public const short ProtocolId = 196;
        public override short TypeId { get { return ProtocolId; } }

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo;
        public JobCrafterDirectoryEntryJobInfo JobInfo;

        public JobCrafterDirectoryListEntry()
        {
        }

        public JobCrafterDirectoryListEntry(
            JobCrafterDirectoryEntryPlayerInfo playerInfo,
            JobCrafterDirectoryEntryJobInfo jobInfo
        )
        {
            PlayerInfo = playerInfo;
            JobInfo = jobInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            PlayerInfo.Serialize(writer);
            JobInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            JobInfo = new JobCrafterDirectoryEntryJobInfo();
            JobInfo.Deserialize(reader);
        }
    }
}