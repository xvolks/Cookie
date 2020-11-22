using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayMonsterNotAngryAtPlayerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6742;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;
        public double MonsterGroupId = 0;

        public GameRolePlayMonsterNotAngryAtPlayerMessage()
        {
        }

        public GameRolePlayMonsterNotAngryAtPlayerMessage(
            long playerId,
            double monsterGroupId
        )
        {
            PlayerId = playerId;
            MonsterGroupId = monsterGroupId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
            writer.WriteDouble(MonsterGroupId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
            MonsterGroupId = reader.ReadDouble();
        }
    }
}