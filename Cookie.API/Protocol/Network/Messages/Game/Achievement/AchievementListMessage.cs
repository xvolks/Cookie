namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    using Types.Game.Achievement;
    using System.Collections.Generic;
    using Utils.IO;

    public class AchievementListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6205;
        public override ushort MessageID => ProtocolId;
        public List<AchievementAchieved> FinishedAchievementsIds { get; set; }
        
        
        public AchievementListMessage(List<AchievementAchieved> finishedAchievementsIds)
        {
            FinishedAchievementsIds = finishedAchievementsIds;
            
        }

        public AchievementListMessage()  {
            FinishedAchievementsIds = new List<AchievementAchieved>();
            
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)FinishedAchievementsIds.Count);
            for (var finishedAchievementsIdsIndex = 0; finishedAchievementsIdsIndex < FinishedAchievementsIds.Count; finishedAchievementsIdsIndex++)
            {
                // todo
                writer.WriteShort((short)(FinishedAchievementsIds[finishedAchievementsIdsIndex]).TypeID);
                FinishedAchievementsIds[finishedAchievementsIdsIndex].Serialize(writer);
            }
        }
        public override void Deserialize(IDataReader reader)
        {
            ushort Id = 0;
            AchievementAchieved achievement;
            var finishedAchievementsIdsCount = reader.ReadUShort();
            for (var finishedAchievementsIdsIndex = 0; finishedAchievementsIdsIndex < finishedAchievementsIdsCount; finishedAchievementsIdsIndex++)
            {
                Id = reader.ReadUShort();
                achievement = ProtocolTypeManager.GetInstance<AchievementAchieved>(Id);
                achievement.Deserialize(reader);
                FinishedAchievementsIds.Add(achievement);
            }
            
           
        }

    }
}
