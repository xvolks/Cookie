using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachRewardsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6813;

        public override ushort MessageID => ProtocolId;

        public List<BreachReward> Rewards { get; set; }
        public BreachReward Save { get; set; }
        public BreachRewardsMessage() { }

        public BreachRewardsMessage( List<BreachReward> Rewards, BreachReward Save ){
            this.Rewards = Rewards;
            this.Save = Save;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Rewards.Count);
			foreach (var x in Rewards)
			{
				x.Serialize(writer);
			}
            Save.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            var RewardsCount = reader.ReadShort();
            Rewards = new List<BreachReward>();
            for (var i = 0; i < RewardsCount; i++)
            {
                var objectToAdd = new BreachReward();
                objectToAdd.Deserialize(reader);
                Rewards.Add(objectToAdd);
            }
            Save = new BreachReward();
            Save.Deserialize(reader);
        }
    }
}
