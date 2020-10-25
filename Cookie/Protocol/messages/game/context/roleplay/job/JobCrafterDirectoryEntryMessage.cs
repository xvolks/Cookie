using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class JobCrafterDirectoryEntryMessage : NetworkMessage
    {
        public const uint ProtocolId = 6044;
        public override uint MessageID { get { return ProtocolId; } }

        public JobCrafterDirectoryEntryPlayerInfo PlayerInfo;
        public List<JobCrafterDirectoryEntryJobInfo> JobInfoList;
        public EntityLook PlayerLook;

        public JobCrafterDirectoryEntryMessage()
        {
        }

        public JobCrafterDirectoryEntryMessage(
            JobCrafterDirectoryEntryPlayerInfo playerInfo,
            List<JobCrafterDirectoryEntryJobInfo> jobInfoList,
            EntityLook playerLook
        )
        {
            PlayerInfo = playerInfo;
            JobInfoList = jobInfoList;
            PlayerLook = playerLook;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            PlayerInfo.Serialize(writer);
            writer.WriteShort((short)JobInfoList.Count());
            foreach (var current in JobInfoList)
            {
                current.Serialize(writer);
            }
            PlayerLook.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
            PlayerInfo.Deserialize(reader);
            var countJobInfoList = reader.ReadShort();
            JobInfoList = new List<JobCrafterDirectoryEntryJobInfo>();
            for (short i = 0; i < countJobInfoList; i++)
            {
                JobCrafterDirectoryEntryJobInfo type = new JobCrafterDirectoryEntryJobInfo();
                type.Deserialize(reader);
                JobInfoList.Add(type);
            }
            PlayerLook = new EntityLook();
            PlayerLook.Deserialize(reader);
        }
    }
}