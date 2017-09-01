using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayShowChallengeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 301;

        public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos)
        {
            CommonsInfos = commonsInfos;
        }

        public GameRolePlayShowChallengeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public FightCommonInformations CommonsInfos { get; set; }

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