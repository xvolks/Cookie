using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6205;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AchievementAchieved> FinishedAchievements;

        public AchievementListMessage()
        {
        }

        public AchievementListMessage(
            List<AchievementAchieved> finishedAchievements
        )
        {
            FinishedAchievements = finishedAchievements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)FinishedAchievements.Count());
            foreach (var current in FinishedAchievements)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFinishedAchievements = reader.ReadShort();
            FinishedAchievements = new List<AchievementAchieved>();
            for (short i = 0; i < countFinishedAchievements; i++)
            {
                var finishedAchievementstypeId = reader.ReadShort();
                AchievementAchieved type = new AchievementAchieved();
                type.Deserialize(reader);
                FinishedAchievements.Add(type);
            }
        }
    }
}