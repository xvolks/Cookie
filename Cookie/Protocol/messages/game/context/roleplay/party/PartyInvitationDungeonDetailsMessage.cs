using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
    {
        public new const uint ProtocolId = 6262;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public List<bool> PlayersDungeonReady;

        public PartyInvitationDungeonDetailsMessage(): base()
        {
        }

        public PartyInvitationDungeonDetailsMessage(
            int partyId,
            byte partyType,
            string partyName,
            long fromId,
            string fromName,
            long leaderId,
            List<PartyInvitationMemberInformations> members,
            List<PartyGuestInformations> guests,
            short dungeonId,
            List<bool> playersDungeonReady
        ): base(
            partyId,
            partyType,
            partyName,
            fromId,
            fromName,
            leaderId,
            members,
            guests
        )
        {
            DungeonId = dungeonId;
            PlayersDungeonReady = playersDungeonReady;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(DungeonId);
            writer.WriteShort((short)PlayersDungeonReady.Count());
            foreach (var current in PlayersDungeonReady)
            {
                writer.WriteBoolean(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarShort();
            var countPlayersDungeonReady = reader.ReadShort();
            PlayersDungeonReady = new List<bool>();
            for (short i = 0; i < countPlayersDungeonReady; i++)
            {
                PlayersDungeonReady.Add(reader.ReadBoolean());
            }
        }
    }
}