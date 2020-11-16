using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayShowChallengeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 301;

        public override ushort MessageID => ProtocolId;

        public FightCommonInformations CommonsInfos { get; set; }
        public GameRolePlayShowChallengeMessage() { }

        public GameRolePlayShowChallengeMessage( FightCommonInformations CommonsInfos ){
            this.CommonsInfos = CommonsInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            CommonsInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            CommonsInfos = new FightCommonInformations();
            CommonsInfos.Deserialize(reader);
        }
    }
}
