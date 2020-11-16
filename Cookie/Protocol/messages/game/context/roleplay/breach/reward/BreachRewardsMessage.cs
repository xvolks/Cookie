using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachRewardsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6813;
        public override uint MessageID { get { return ProtocolId; } }

        public List<BreachReward> Rewards;
        public BreachReward Save;

        public BreachRewardsMessage()
        {
        }

        public BreachRewardsMessage(
            List<BreachReward> rewards,
            BreachReward save
        )
        {
            Rewards = rewards;
            Save = save;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Rewards.Count());
            foreach (var current in Rewards)
            {
                current.Serialize(writer);
            }
            Save.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countRewards = reader.ReadShort();
            Rewards = new List<BreachReward>();
            for (short i = 0; i < countRewards; i++)
            {
                BreachReward type = new BreachReward();
                type.Deserialize(reader);
                Rewards.Add(type);
            }
            Save = new BreachReward();
            Save.Deserialize(reader);
        }
    }
}