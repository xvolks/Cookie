using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
    {
        public new const ushort ProtocolId = 6500;

        public MapRunningFightDetailsExtendedMessage(List<NamedPartyTeam> namedPartyTeams)
        {
            NamedPartyTeams = namedPartyTeams;
        }

        public MapRunningFightDetailsExtendedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<NamedPartyTeam> NamedPartyTeams { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) NamedPartyTeams.Count);
            for (var namedPartyTeamsIndex = 0; namedPartyTeamsIndex < NamedPartyTeams.Count; namedPartyTeamsIndex++)
            {
                var objectToSend = NamedPartyTeams[namedPartyTeamsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var namedPartyTeamsCount = reader.ReadUShort();
            NamedPartyTeams = new List<NamedPartyTeam>();
            for (var namedPartyTeamsIndex = 0; namedPartyTeamsIndex < namedPartyTeamsCount; namedPartyTeamsIndex++)
            {
                var objectToAdd = new NamedPartyTeam();
                objectToAdd.Deserialize(reader);
                NamedPartyTeams.Add(objectToAdd);
            }
        }
    }
}