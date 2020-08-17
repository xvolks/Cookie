using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Achievement;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6205;

        public AchievementListMessage(List<ushort> finishedAchievementsIds,
            List<AchievementRewardable> rewardableAchievements)
        {
            FinishedAchievementsIds = finishedAchievementsIds;
            RewardableAchievements = rewardableAchievements;
        }

        public AchievementListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> FinishedAchievementsIds { get; set; }
        public List<AchievementRewardable> RewardableAchievements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) FinishedAchievementsIds.Count);
            for (var finishedAchievementsIdsIndex = 0;
                finishedAchievementsIdsIndex < FinishedAchievementsIds.Count;
                finishedAchievementsIdsIndex++)
                writer.WriteVarUhShort(FinishedAchievementsIds[finishedAchievementsIdsIndex]);
            writer.WriteShort((short) RewardableAchievements.Count);
            for (var rewardableAchievementsIndex = 0;
                rewardableAchievementsIndex < RewardableAchievements.Count;
                rewardableAchievementsIndex++)
            {
                var objectToSend = RewardableAchievements[rewardableAchievementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var finishedAchievementsIdsCount = reader.ReadUShort();
            FinishedAchievementsIds = new List<ushort>();
            for (var finishedAchievementsIdsIndex = 0;
                finishedAchievementsIdsIndex < finishedAchievementsIdsCount;
                finishedAchievementsIdsIndex++)
                FinishedAchievementsIds.Add(reader.ReadVarUhShort());
            var rewardableAchievementsCount = reader.ReadUShort();
            RewardableAchievements = new List<AchievementRewardable>();
            for (var rewardableAchievementsIndex = 0;
                rewardableAchievementsIndex < rewardableAchievementsCount;
                rewardableAchievementsIndex++)
            {
                var objectToAdd = new AchievementRewardable();
                objectToAdd.Deserialize(reader);
                RewardableAchievements.Add(objectToAdd);
            }
        }
    }
}