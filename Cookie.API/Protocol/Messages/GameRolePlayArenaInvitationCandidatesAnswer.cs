using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaInvitationCandidatesAnswer : NetworkMessage
    {
        public const ushort ProtocolId = 6783;

        public override ushort MessageID => ProtocolId;

        public List<LeagueFriendInformations> Candidates { get; set; }
        public GameRolePlayArenaInvitationCandidatesAnswer() { }

        public GameRolePlayArenaInvitationCandidatesAnswer( List<LeagueFriendInformations> Candidates ){
            this.Candidates = Candidates;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Candidates.Count);
			foreach (var x in Candidates)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CandidatesCount = reader.ReadShort();
            Candidates = new List<LeagueFriendInformations>();
            for (var i = 0; i < CandidatesCount; i++)
            {
                var objectToAdd = new LeagueFriendInformations();
                objectToAdd.Deserialize(reader);
                Candidates.Add(objectToAdd);
            }
        }
    }
}
