using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6191;

        public GameRolePlayAttackMonsterRequestMessage(double monsterGroupId)
        {
            MonsterGroupId = monsterGroupId;
        }

        public GameRolePlayAttackMonsterRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double MonsterGroupId { get; set; }

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