namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using Utils.IO;

    public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6191;
        public override ushort MessageID => ProtocolId;
        public double MonsterGroupId { get; set; }

        public GameRolePlayAttackMonsterRequestMessage(double monsterGroupId)
        {
            MonsterGroupId = monsterGroupId;
        }

        public GameRolePlayAttackMonsterRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MonsterGroupId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MonsterGroupId = reader.ReadDouble();
        }

    }
}
