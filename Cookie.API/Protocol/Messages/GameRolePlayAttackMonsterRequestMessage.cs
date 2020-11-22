using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6191;

        public override ushort MessageID => ProtocolId;

        public double MonsterGroupId { get; set; }
        public GameRolePlayAttackMonsterRequestMessage() { }

        public GameRolePlayAttackMonsterRequestMessage( double MonsterGroupId ){
            this.MonsterGroupId = MonsterGroupId;
        }

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
