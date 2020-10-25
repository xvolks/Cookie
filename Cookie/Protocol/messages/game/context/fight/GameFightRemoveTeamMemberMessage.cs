using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightRemoveTeamMemberMessage : NetworkMessage
    {
        public const uint ProtocolId = 711;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public byte TeamId = 2;
        public double CharId = 0;

        public GameFightRemoveTeamMemberMessage()
        {
        }

        public GameFightRemoveTeamMemberMessage(
            short fightId,
            byte teamId,
            double charId
        )
        {
            FightId = fightId;
            TeamId = teamId;
            CharId = charId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteByte(TeamId);
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            TeamId = reader.ReadByte();
            CharId = reader.ReadDouble();
        }
    }
}