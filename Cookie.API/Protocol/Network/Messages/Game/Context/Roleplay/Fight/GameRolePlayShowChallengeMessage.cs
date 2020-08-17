namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using Types.Game.Context.Fight;
    using Utils.IO;

    public class GameRolePlayShowChallengeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 301;
        public override ushort MessageID => ProtocolId;
        public FightCommonInformations CommonsInfos { get; set; }

        public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos)
        {
            CommonsInfos = commonsInfos;
        }

        public GameRolePlayShowChallengeMessage() { }

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
