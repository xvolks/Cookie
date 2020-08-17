using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    public class GameRolePlayAggressionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6073;

        public GameRolePlayAggressionMessage(ulong attackerId, ulong defenderId)
        {
            AttackerId = attackerId;
            DefenderId = defenderId;
        }

        public GameRolePlayAggressionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong AttackerId { get; set; }
        public ulong DefenderId { get; set; }

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