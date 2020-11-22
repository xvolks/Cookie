using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public new const ushort ProtocolId = 33;

        public override ushort TypeID => ProtocolId;

        public List<FightTeamMemberInformations> TeamMembers { get; set; }
        public FightTeamInformations() { }

        public FightTeamInformations( List<FightTeamMemberInformations> TeamMembers ){
            this.TeamMembers = TeamMembers;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)TeamMembers.Count);
			foreach (var x in TeamMembers)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var TeamMembersCount = reader.ReadShort();
            TeamMembers = new List<FightTeamMemberInformations>();
            for (var i = 0; i < TeamMembersCount; i++)
            {
                FightTeamMemberInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                TeamMembers.Add(objectToAdd);
            }
        }
    }
}
