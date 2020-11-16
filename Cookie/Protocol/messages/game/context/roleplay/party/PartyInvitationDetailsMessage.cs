using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationDetailsMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6263;
        public override uint MessageID { get { return ProtocolId; } }

        public byte PartyType = 0;
        public string PartyName;
        public long FromId = 0;
        public string FromName;
        public long LeaderId = 0;
        public List<PartyInvitationMemberInformations> Members;
        public List<PartyGuestInformations> Guests;

        public PartyInvitationDetailsMessage(): base()
        {
        }

        public PartyInvitationDetailsMessage(
            int partyId,
            byte partyType,
            string partyName,
            long fromId,
            string fromName,
            long leaderId,
            List<PartyInvitationMemberInformations> members,
            List<PartyGuestInformations> guests
        ): base(
            partyId
        )
        {
            PartyType = partyType;
            PartyName = partyName;
            FromId = fromId;
            FromName = fromName;
            LeaderId = leaderId;
            Members = members;
            Guests = guests;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PartyType);
            writer.WriteUTF(PartyName);
            writer.WriteVarLong(FromId);
            writer.WriteUTF(FromName);
            writer.WriteVarLong(LeaderId);
            writer.WriteShort((short)Members.Count());
            foreach (var current in Members)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)Guests.Count());
            foreach (var current in Guests)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadByte();
            PartyName = reader.ReadUTF();
            FromId = reader.ReadVarLong();
            FromName = reader.ReadUTF();
            LeaderId = reader.ReadVarLong();
            var countMembers = reader.ReadShort();
            Members = new List<PartyInvitationMemberInformations>();
            for (short i = 0; i < countMembers; i++)
            {
                var memberstypeId = reader.ReadShort();
                PartyInvitationMemberInformations type = new PartyInvitationMemberInformations();
                type.Deserialize(reader);
                Members.Add(type);
            }
            var countGuests = reader.ReadShort();
            Guests = new List<PartyGuestInformations>();
            for (short i = 0; i < countGuests; i++)
            {
                PartyGuestInformations type = new PartyGuestInformations();
                type.Deserialize(reader);
                Guests.Add(type);
            }
        }
    }
}