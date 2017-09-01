namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Types.Game.Dare;
    using System.Collections.Generic;
    using Utils.IO;

    public class DareRewardsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6677;
        public override ushort MessageID => ProtocolId;
        public List<DareReward> Rewards { get; set; }

        public DareRewardsListMessage(List<DareReward> rewards)
        {
            Rewards = rewards;
        }

        public DareRewardsListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Rewards.Count);
            for (var rewardsIndex = 0; rewardsIndex < Rewards.Count; rewardsIndex++)
            {
                var objectToSend = Rewards[rewardsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var rewardsCount = reader.ReadUShort();
            Rewards = new List<DareReward>();
            for (var rewardsIndex = 0; rewardsIndex < rewardsCount; rewardsIndex++)
            {
                var objectToAdd = new DareReward();
                objectToAdd.Deserialize(reader);
                Rewards.Add(objectToAdd);
            }
        }

    }
}
