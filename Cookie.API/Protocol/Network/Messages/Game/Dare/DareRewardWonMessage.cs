using Cookie.API.Protocol.Network.Types.Game.Dare;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareRewardWonMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6678;

        public DareRewardWonMessage(DareReward reward)
        {
            Reward = reward;
        }

        public DareRewardWonMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public DareReward Reward { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Reward.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reward = new DareReward();
            Reward.Deserialize(reader);
        }
    }
}