using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AchievementDetailsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6378;
        public override uint MessageID { get { return ProtocolId; } }

        public Achievement Achievement_;

        public AchievementDetailsMessage()
        {
        }

        public AchievementDetailsMessage(
            Achievement achievement_
        )
        {
            Achievement_ = achievement_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Achievement_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Achievement_ = new Achievement();
            Achievement_.Deserialize(reader);
        }
    }
}