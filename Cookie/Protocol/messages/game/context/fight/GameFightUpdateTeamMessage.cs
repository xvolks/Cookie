using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightUpdateTeamMessage : NetworkMessage
    {
        public const uint ProtocolId = 5572;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public FightTeamInformations Team;

        public GameFightUpdateTeamMessage()
        {
        }

        public GameFightUpdateTeamMessage(
            short fightId,
            FightTeamInformations team
        )
        {
            FightId = fightId;
            Team = team;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            Team.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            Team = new FightTeamInformations();
            Team.Deserialize(reader);
        }
    }
}