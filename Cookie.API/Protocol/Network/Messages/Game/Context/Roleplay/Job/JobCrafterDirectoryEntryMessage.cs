using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobCrafterDirectoryEntryMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6044;

        public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo,
            List<JobCrafterDirectoryEntryJobInfo> jobInfoList, EntityLook playerLook)
        {
            PlayerInfo = playerInfo;
            JobInfoList = jobInfoList;
            PlayerLook = playerLook;
        }

        public JobCrafterDirectoryEntryMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
        public List<JobCrafterDirectoryEntryJobInfo> JobInfoList { get; set; }
        public EntityLook PlayerLook { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PlayerInfo.Serialize(writer);
            writer.WriteShort((short) JobInfoList.Count);
            for (var jobInfoListIndex = 0; jobInfoListIndex < JobInfoList.Count; jobInfoListIndex++)
            {
                var objectToSend = JobInfoList[jobInfoListIndex];
                objectToSend.Serialize(writer);
            }
            PlayerLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            var jobInfoListCount = reader.ReadUShort();
            JobInfoList = new List<JobCrafterDirectoryEntryJobInfo>();
            for (var jobInfoListIndex = 0; jobInfoListIndex < jobInfoListCount; jobInfoListIndex++)
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