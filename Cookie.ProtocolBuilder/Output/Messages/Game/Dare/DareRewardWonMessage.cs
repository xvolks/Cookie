namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using Utils.IO;

    public class DareRewardWonMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6678;
        public override ushort MessageID => ProtocolId;
        public DareReward Reward { get; set; }

        public DareRewardWonMessage(DareReward reward)
        {
            Reward = reward;
        }

        public DareRewardWonMessage() { }

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
