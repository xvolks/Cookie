using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DareRewardsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6677;
        public override uint MessageID { get { return ProtocolId; } }

        public List<DareReward> Rewards;

        public DareRewardsListMessage()
        {
        }

        public DareRewardsListMessage(
            List<DareReward> rewards
        )
        {
            Rewards = rewards;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Rewards.Count());
            foreach (var current in Rewards)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countRewards = reader.ReadShort();
            Rewards = new List<DareReward>();
            for (short i = 0; i < countRewards; i++)
            {
                DareReward type = new DareReward();
                type.Deserialize(reader);
                Rewards.Add(type);
            }
        }
    }
}