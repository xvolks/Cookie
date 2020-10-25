using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightSpectatorJoinMessage : GameFightJoinMessage
    {
        public new const uint ProtocolId = 6504;
        public override uint MessageID { get { return ProtocolId; } }

        public List<NamedPartyTeam> NamedPartyTeams;

        public GameFightSpectatorJoinMessage(): base()
        {
        }

        public GameFightSpectatorJoinMessage(
            bool isTeamPhase,
            bool canBeCancelled,
            bool canSayReady,
            bool isFightStarted,
            short timeMaxBeforeFightStart,
            byte fightType,
            List<NamedPartyTeam> namedPartyTeams
        ): base(
            isTeamPhase,
            canBeCancelled,
            canSayReady,
            isFightStarted,
            timeMaxBeforeFightStart,
            fightType
        )
        {
            NamedPartyTeams = namedPartyTeams;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)NamedPartyTeams.Count());
            foreach (var current in NamedPartyTeams)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countNamedPartyTeams = reader.ReadShort();
            NamedPartyTeams = new List<NamedPartyTeam>();
            for (short i = 0; i < countNamedPartyTeams; i++)
            {
                NamedPartyTeam type = new NamedPartyTeam();
                type.Deserialize(reader);
                NamedPartyTeams.Add(type);
            }
        }
    }
}