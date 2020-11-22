using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareRewardWonMessage : NetworkMessage
    {
        public const uint ProtocolId = 6678;
        public override uint MessageID { get { return ProtocolId; } }

        public DareReward Reward;

        public DareRewardWonMessage()
        {
        }

        public DareRewardWonMessage(
            DareReward reward
        )
        {
            Reward = reward;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Reward.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Reward = new DareReward();
            Reward.Deserialize(reader);
        }
    }
}