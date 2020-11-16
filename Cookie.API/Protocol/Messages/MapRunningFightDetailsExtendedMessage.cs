using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
    {
        public new const ushort ProtocolId = 6500;

        public override ushort MessageID => ProtocolId;

        public List<NamedPartyTeam> NamedPartyTeams { get; set; }
        public MapRunningFightDetailsExtendedMessage() { }

        public MapRunningFightDetailsExtendedMessage( List<NamedPartyTeam> NamedPartyTeams ){
            this.NamedPartyTeams = NamedPartyTeams;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)NamedPartyTeams.Count);
			foreach (var x in NamedPartyTeams)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var NamedPartyTeamsCount = reader.ReadShort();
            NamedPartyTeams = new List<NamedPartyTeam>();
            for (var i = 0; i < NamedPartyTeamsCount; i++)
            {
                var objectToAdd = new NamedPartyTeam();
                objectToAdd.Deserialize(reader);
                NamedPartyTeams.Add(objectToAdd);
            }
        }
    }
}
