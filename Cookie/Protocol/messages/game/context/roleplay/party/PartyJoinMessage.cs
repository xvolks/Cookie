using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyJoinMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5576;
        public override uint MessageID { get { return ProtocolId; } }

        public byte PartyType = 0;
        public long PartyLeaderId = 0;
        public byte MaxParticipants = 0;
        public List<PartyMemberInformations> Members;
        public List<PartyGuestInformations> Guests;
        public bool Restricted = false;
        public string PartyName;

        public PartyJoinMessage(): base()
        {
        }

        public PartyJoinMessage(
            int partyId,
            byte partyType,
            long partyLeaderId,
            byte maxParticipants,
            List<PartyMemberInformations> members,
            List<PartyGuestInformations> guests,
            bool restricted,
            string partyName
        ): base(
            partyId
        )
        {
            PartyType = partyType;
            PartyLeaderId = partyLeaderId;
            MaxParticipants = maxParticipants;
            Members = members;
            Guests = guests;
            Restricted = restricted;
            PartyName = partyName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PartyType);
            writer.WriteVarLong(PartyLeaderId);
            writer.WriteByte(MaxParticipants);
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
            writer.WriteBoolean(Restricted);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadByte();
            PartyLeaderId = reader.ReadVarLong();
            MaxParticipants = reader.ReadByte();
            var countMembers = reader.ReadShort();
            Members = new List<PartyMemberInformations>();
            for (short i = 0; i < countMembers; i++)
            {
                var memberstypeId = reader.ReadShort();
                PartyMemberInformations type = new PartyMemberInformations();
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
            Restricted = reader.ReadBoolean();
            PartyName = reader.ReadUTF();
        }
    }
}