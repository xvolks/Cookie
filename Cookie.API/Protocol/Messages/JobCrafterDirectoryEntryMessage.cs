using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class JobCrafterDirectoryEntryMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6044;

        public override ushort MessageID => ProtocolId;

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public List<JobCrafterDirectoryEntryJobInfo> JobInfoList { get; set; }
        public EntityLook PlayerLook { get; set; }
        public JobCrafterDirectoryEntryMessage() { }

        public JobCrafterDirectoryEntryMessage( JobCrafterDirectoryEntryPlayerInfo PlayerInfo, List<JobCrafterDirectoryEntryJobInfo> JobInfoList, EntityLook PlayerLook ){
            this.PlayerInfo = PlayerInfo;
            this.JobInfoList = JobInfoList;
            this.PlayerLook = PlayerLook;
        }

        public override void Serialize(IDataWriter writer)
        {
            PlayerInfo.Serialize(writer);
			writer.WriteShort((short)JobInfoList.Count);
			foreach (var x in JobInfoList)
			{
				x.Serialize(writer);
			}
            PlayerLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            var JobInfoListCount = reader.ReadShort();
            JobInfoList = new List<JobCrafterDirectoryEntryJobInfo>();
            for (var i = 0; i < JobInfoListCount; i++)
            {
                var objectToAdd = new JobCrafterDirectoryEntryJobInfo();
                objectToAdd.Deserialize(reader);
                JobInfoList.Add(objectToAdd);
            }
            PlayerLook = new EntityLook();
            PlayerLook.Deserialize(reader);
        }
    }
}
