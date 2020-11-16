using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaFighterStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6281;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public double PlayerId = 0;
        public bool Accepted = false;

        public GameRolePlayArenaFighterStatusMessage()
        {
        }

        public GameRolePlayArenaFighterStatusMessage(
            short fightId,
            double playerId,
            bool accepted
        )
        {
            FightId = fightId;
            PlayerId = playerId;
            Accepted = accepted;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteDouble(PlayerId);
            writer.WriteBoolean(Accepted);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            PlayerId = reader.ReadDouble();
            Accepted = reader.ReadBoolean();
        }
    }
}