using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayShowChallengeMessage : NetworkMessage
    {
        public const uint ProtocolId = 301;
        public override uint MessageID { get { return ProtocolId; } }

        public FightCommonInformations CommonsInfos;

        public GameRolePlayShowChallengeMessage()
        {
        }

        public GameRolePlayShowChallengeMessage(
            FightCommonInformations commonsInfos
        )
        {
            CommonsInfos = commonsInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            CommonsInfos.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CommonsInfos = new FightCommonInformations();
            CommonsInfos.Deserialize(reader);
        }
    }
}