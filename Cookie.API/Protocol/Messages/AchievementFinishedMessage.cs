using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6208;

        public override ushort MessageID => ProtocolId;

        public AchievementAchievedRewardable Achievement { get; set; }
        public AchievementFinishedMessage() { }

        public AchievementFinishedMessage( AchievementAchievedRewardable Achievement ){
            this.Achievement = Achievement;
        }

        public override void Serialize(IDataWriter writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Achievement = new AchievementAchievedRewardable();
            Achievement.Deserialize(reader);
        }
    }
}
