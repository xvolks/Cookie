using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class JobCrafterDirectoryListEntry : NetworkType
    {
        public const ushort ProtocolId = 196;

        public override ushort TypeID => ProtocolId;

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }
        public JobCrafterDirectoryListEntry() { }

        public JobCrafterDirectoryListEntry( JobCrafterDirectoryEntryPlayerInfo PlayerInfo, JobCrafterDirectoryEntryJobInfo JobInfo ){
            this.PlayerInfo = PlayerInfo;
            this.JobInfo = JobInfo;
        }

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
