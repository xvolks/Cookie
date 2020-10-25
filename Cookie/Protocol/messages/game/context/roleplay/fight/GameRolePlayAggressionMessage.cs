using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayAggressionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6073;
        public override uint MessageID { get { return ProtocolId; } }

        public long AttackerId = 0;
        public long DefenderId = 0;

        public GameRolePlayAggressionMessage()
        {
        }

        public GameRolePlayAggressionMessage(
            long attackerId,
            long defenderId
        )
        {
            AttackerId = attackerId;
            DefenderId = defenderId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(AttackerId);
            writer.WriteVarLong(DefenderId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AttackerId = reader.ReadVarLong();
            DefenderId = reader.ReadVarLong();
        }
    }
}