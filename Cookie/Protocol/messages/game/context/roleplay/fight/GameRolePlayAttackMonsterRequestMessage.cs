using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6191;
        public override uint MessageID { get { return ProtocolId; } }

        public double MonsterGroupId = 0;

        public GameRolePlayAttackMonsterRequestMessage()
        {
        }

        public GameRolePlayAttackMonsterRequestMessage(
            double monsterGroupId
        )
        {
            MonsterGroupId = monsterGroupId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MonsterGroupId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MonsterGroupId = reader.ReadDouble();
        }
    }
}