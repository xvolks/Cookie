using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayMonsterAngryAtPlayerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6741;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;
        public double MonsterGroupId = 0;
        public double AngryStartTime = 0;
        public double AttackTime = 0;

        public GameRolePlayMonsterAngryAtPlayerMessage()
        {
        }

        public GameRolePlayMonsterAngryAtPlayerMessage(
            long playerId,
            double monsterGroupId,
            double angryStartTime,
            double attackTime
        )
        {
            PlayerId = playerId;
            MonsterGroupId = monsterGroupId;
            AngryStartTime = angryStartTime;
            AttackTime = attackTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
            writer.WriteDouble(MonsterGroupId);
            writer.WriteDouble(AngryStartTime);
            writer.WriteDouble(AttackTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
            MonsterGroupId = reader.ReadDouble();
            AngryStartTime = reader.ReadDouble();
            AttackTime = reader.ReadDouble();
        }
    }
}