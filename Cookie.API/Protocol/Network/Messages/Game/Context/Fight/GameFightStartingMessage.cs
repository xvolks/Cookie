using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightStartingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 700;

        public GameFightStartingMessage(byte fightType, double attackerId, double defenderId)
        {
            FightType = fightType;
            AttackerId = attackerId;
            DefenderId = defenderId;
        }

        public GameFightStartingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte FightType { get; set; }
        public double AttackerId { get; set; }
        public double DefenderId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(FightType);
            writer.WriteDouble(AttackerId);
            writer.WriteDouble(DefenderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightType = reader.ReadByte();
            AttackerId = reader.ReadDouble();
            DefenderId = reader.ReadDouble();
        }
    }
}