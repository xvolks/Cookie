using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareRewardWonMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6678;

        public override ushort MessageID => ProtocolId;

        public DareReward Reward { get; set; }
        public DareRewardWonMessage() { }

        public DareRewardWonMessage( DareReward Reward ){
            this.Reward = Reward;
        }

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
