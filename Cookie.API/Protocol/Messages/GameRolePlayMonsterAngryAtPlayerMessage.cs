using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayMonsterAngryAtPlayerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6741;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public double MonsterGroupId { get; set; }
        public double AngryStartTime { get; set; }
        public double AttackTime { get; set; }
        public GameRolePlayMonsterAngryAtPlayerMessage() { }

        public GameRolePlayMonsterAngryAtPlayerMessage( ulong PlayerId, double MonsterGroupId, double AngryStartTime, double AttackTime ){
            this.PlayerId = PlayerId;
            this.MonsterGroupId = MonsterGroupId;
            this.AngryStartTime = AngryStartTime;
            this.AttackTime = AttackTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteDouble(MonsterGroupId);
            writer.WriteDouble(AngryStartTime);
            writer.WriteDouble(AttackTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            MonsterGroupId = reader.ReadDouble();
            AngryStartTime = reader.ReadDouble();
            AttackTime = reader.ReadDouble();
        }
    }
}
