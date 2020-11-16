using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementDetailedListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6358;

        public override ushort MessageID => ProtocolId;

        public List<Achievement> StartedAchievements { get; set; }
        public List<Achievement> FinishedAchievements { get; set; }
        public AchievementDetailedListMessage() { }

        public AchievementDetailedListMessage( List<Achievement> StartedAchievements, List<Achievement> FinishedAchievements ){
            this.StartedAchievements = StartedAchievements;
            this.FinishedAchievements = FinishedAchievements;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)StartedAchievements.Count);
			foreach (var x in StartedAchievements)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)FinishedAchievements.Count);
			foreach (var x in FinishedAchievements)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var StartedAchievementsCount = reader.ReadShort();
            StartedAchievements = new List<Achievement>();
            for (var i = 0; i < StartedAchievementsCount; i++)
            {
                var objectToAdd = new Achievement();
                objectToAdd.Deserialize(reader);
                StartedAchievements.Add(objectToAdd);
            }
            var FinishedAchievementsCount = reader.ReadShort();
            FinishedAchievements = new List<Achievement>();
            for (var i = 0; i < FinishedAchievementsCount; i++)
            {
                var objectToAdd = new Achievement();
                objectToAdd.Deserialize(reader);
                FinishedAchievements.Add(objectToAdd);
            }
        }
    }
}
