using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaInvitationCandidatesAnswer : NetworkMessage
    {
        public const uint ProtocolId = 6783;
        public override uint MessageID { get { return ProtocolId; } }

        public List<LeagueFriendInformations> Candidates;

        public GameRolePlayArenaInvitationCandidatesAnswer()
        {
        }

        public GameRolePlayArenaInvitationCandidatesAnswer(
            List<LeagueFriendInformations> candidates
        )
        {
            Candidates = candidates;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Candidates.Count());
            foreach (var current in Candidates)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCandidates = reader.ReadShort();
            Candidates = new List<LeagueFriendInformations>();
            for (short i = 0; i < countCandidates; i++)
            {
                LeagueFriendInformations type = new LeagueFriendInformations();
                type.Deserialize(reader);
                Candidates.Add(type);
            }
        }
    }
}