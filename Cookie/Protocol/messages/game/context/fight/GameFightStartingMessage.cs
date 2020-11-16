using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightStartingMessage : NetworkMessage
    {
        public const uint ProtocolId = 700;
        public override uint MessageID { get { return ProtocolId; } }

        public byte FightType = 0;
        public short FightId = 0;
        public double AttackerId = 0;
        public double DefenderId = 0;

        public GameFightStartingMessage()
        {
        }

        public GameFightStartingMessage(
            byte fightType,
            short fightId,
            double attackerId,
            double defenderId
        )
        {
            FightType = fightType;
            FightId = fightId;
            AttackerId = attackerId;
            DefenderId = defenderId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(FightType);
            writer.WriteVarShort(FightId);
            writer.WriteDouble(AttackerId);
            writer.WriteDouble(DefenderId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightType = reader.ReadByte();
            FightId = reader.ReadVarShort();
            AttackerId = reader.ReadDouble();
            DefenderId = reader.ReadDouble();
        }
    }
}