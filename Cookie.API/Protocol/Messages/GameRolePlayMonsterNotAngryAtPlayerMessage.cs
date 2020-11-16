using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayMonsterNotAngryAtPlayerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6742;

        public override ushort MessageID => ProtocolId;

        public ulong PlayerId { get; set; }
        public double MonsterGroupId { get; set; }
        public GameRolePlayMonsterNotAngryAtPlayerMessage() { }

        public GameRolePlayMonsterNotAngryAtPlayerMessage( ulong PlayerId, double MonsterGroupId ){
            this.PlayerId = PlayerId;
            this.MonsterGroupId = MonsterGroupId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteDouble(MonsterGroupId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            MonsterGroupId = reader.ReadDouble();
        }
    }
}
