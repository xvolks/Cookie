using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightJoinRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 701;
        public override uint MessageID { get { return ProtocolId; } }

        public double FighterId = 0;
        public short FightId = 0;

        public GameFightJoinRequestMessage()
        {
        }

        public GameFightJoinRequestMessage(
            double fighterId,
            short fightId
        )
        {
            FighterId = fighterId;
            FightId = fightId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(FighterId);
            writer.WriteVarShort(FightId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FighterId = reader.ReadDouble();
            FightId = reader.ReadVarShort();
        }
    }
}