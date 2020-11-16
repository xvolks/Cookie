using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareRewardsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6677;

        public override ushort MessageID => ProtocolId;

        public List<DareReward> Rewards { get; set; }
        public DareRewardsListMessage() { }

        public DareRewardsListMessage( List<DareReward> Rewards ){
            this.Rewards = Rewards;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Rewards.Count);
			foreach (var x in Rewards)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var RewardsCount = reader.ReadShort();
            Rewards = new List<DareReward>();
            for (var i = 0; i < RewardsCount; i++)
            {
                var objectToAdd = new DareReward();
                objectToAdd.Deserialize(reader);
                Rewards.Add(objectToAdd);
            }
        }
    }
}
