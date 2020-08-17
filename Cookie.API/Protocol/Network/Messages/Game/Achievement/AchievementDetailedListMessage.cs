using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Achievement
{
    public class AchievementDetailedListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6358;

        public AchievementDetailedListMessage(List<Types.Game.Achievement.Achievement> startedAchievements,
            List<Types.Game.Achievement.Achievement> finishedAchievements)
        {
            StartedAchievements = startedAchievements;
            FinishedAchievements = finishedAchievements;
        }

        public AchievementDetailedListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<Types.Game.Achievement.Achievement> StartedAchievements { get; set; }
        public List<Types.Game.Achievement.Achievement> FinishedAchievements { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) StartedAchievements.Count);
            for (var startedAchievementsIndex = 0;
                startedAchievementsIndex < StartedAchievements.Count;
                startedAchievementsIndex++)
            {
                var objectToSend = StartedAchievements[startedAchievementsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) FinishedAchievements.Count);
            for (var finishedAchievementsIndex = 0;
                finishedAchievementsIndex < FinishedAchievements.Count;
                finishedAchievementsIndex++)
            {
                var objectToSend = FinishedAchievements[finishedAchievementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var startedAchievementsCount = reader.ReadUShort();
            StartedAchievements = new List<Types.Game.Achievement.Achievement>();
            for (var startedAchievementsIndex = 0;
                startedAchievementsIndex < startedAchievementsCount;
                startedAchievementsIndex++)
            {
                var objectToAdd = new Types.Game.Achievement.Achievement();
                objectToAdd.Deserialize(reader);
                StartedAchievements.Add(objectToAdd);
            }
            var finishedAchievementsCount = reader.ReadUShort();
            FinishedAchievements = new List<Types.Game.Achievement.Achievement>();
            for (var finishedAchievementsIndex = 0;
                finishedAchievementsIndex < finishedAchievementsCount;
                finishedAchievementsIndex++)
            {
                var objectToAdd = new Types.Game.Achievement.Achievement();
                objectToAdd.Deserialize(reader);
                FinishedAchievements.Add(objectToAdd);
            }
        }
    }
}