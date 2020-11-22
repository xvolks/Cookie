using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayAggressionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6073;

        public override ushort MessageID => ProtocolId;

        public ulong AttackerId { get; set; }
        public ulong DefenderId { get; set; }
        public GameRolePlayAggressionMessage() { }

        public GameRolePlayAggressionMessage( ulong AttackerId, ulong DefenderId ){
            this.AttackerId = AttackerId;
            this.DefenderId = DefenderId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(AttackerId);
            writer.WriteVarUhLong(DefenderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AttackerId = reader.ReadVarUhLong();
            DefenderId = reader.ReadVarUhLong();
        }
    }
}
