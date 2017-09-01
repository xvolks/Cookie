namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using Utils.IO;

    public class GameRolePlayRemoveChallengeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 300;
        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }

        public GameRolePlayRemoveChallengeMessage(int fightId)
        {
            FightId = fightId;
        }

        public GameRolePlayRemoveChallengeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
        }

    }
}
