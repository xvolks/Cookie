using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
    {
        public new const uint ProtocolId = 6500;
        public override uint MessageID { get { return ProtocolId; } }

        public List<NamedPartyTeam> NamedPartyTeams;

        public MapRunningFightDetailsExtendedMessage(): base()
        {
        }

        public MapRunningFightDetailsExtendedMessage(
            short fightId,
            List<GameFightFighterLightInformations> attackers,
            List<GameFightFighterLightInformations> defenders,
            List<NamedPartyTeam> namedPartyTeams
        ): base(
            fightId,
            attackers,
            defenders
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