using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6205;

        public override ushort MessageID => ProtocolId;

        public List<AchievementAchieved> FinishedAchievements { get; set; }
        public AchievementListMessage() { }

        public AchievementListMessage( List<AchievementAchieved> FinishedAchievements ){
            this.FinishedAchievements = FinishedAchievements;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)FinishedAchievements.Count);
			foreach (var x in FinishedAchievements)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FinishedAchievementsCount = reader.ReadShort();
            FinishedAchievements = new List<AchievementAchieved>();
            for (var i = 0; i < FinishedAchievementsCount; i++)
            {
                AchievementAchieved objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                FinishedAchievements.Add(objectToAdd);
            }
        }
    }
}
