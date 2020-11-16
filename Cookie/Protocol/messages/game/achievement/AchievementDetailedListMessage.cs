using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementDetailedListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6358;
        public override uint MessageID { get { return ProtocolId; } }

        public List<Achievement> StartedAchievements;
        public List<Achievement> FinishedAchievements;

        public AchievementDetailedListMessage()
        {
        }

        public AchievementDetailedListMessage(
            List<Achievement> startedAchievements,
            List<Achievement> finishedAchievements
        )
        {
            StartedAchievements = startedAchievements;
            FinishedAchievements = finishedAchievements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)StartedAchievements.Count());
            foreach (var current in StartedAchievements)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)FinishedAchievements.Count());
            foreach (var current in FinishedAchievements)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countStartedAchievements = reader.ReadShort();
            StartedAchievements = new List<Achievement>();
            for (short i = 0; i < countStartedAchievements; i++)
            {
                Achievement type = new Achievement();
                type.Deserialize(reader);
                StartedAchievements.Add(type);
            }
            var countFinishedAchievements = reader.ReadShort();
            FinishedAchievements = new List<Achievement>();
            for (short i = 0; i < countFinishedAchievements; i++)
            {
                Achievement type = new Achievement();
                type.Deserialize(reader);
                FinishedAchievements.Add(type);
            }
        }
    }
}