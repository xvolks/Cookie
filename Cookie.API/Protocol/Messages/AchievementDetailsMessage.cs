using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementDetailsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6378;

        public override ushort MessageID => ProtocolId;

        public Achievement Achievement { get; set; }
        public AchievementDetailsMessage() { }

        public AchievementDetailsMessage( Achievement Achievement ){
            this.Achievement = Achievement;
        }

        public override void Serialize(IDataWriter writer)
        {
            Achievement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Achievement = new Achievement();
            Achievement.Deserialize(reader);
        }
    }
}
