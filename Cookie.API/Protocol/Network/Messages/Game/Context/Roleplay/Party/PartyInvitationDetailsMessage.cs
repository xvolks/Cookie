using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationDetailsMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6263;

        public PartyInvitationDetailsMessage(byte partyType, string partyName, ulong fromId, string fromName,
            ulong leaderId, List<PartyInvitationMemberInformations> members, List<PartyGuestInformations> guests)
        {
            PartyType = partyType;
            PartyName = partyName;
            FromId = fromId;
            FromName = fromName;
            LeaderId = leaderId;
            Members = members;
            Guests = guests;
        }

        public PartyInvitationDetailsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PartyType { get; set; }
        public string PartyName { get; set; }
        public ulong FromId { get; set; }
        public string FromName { get; set; }
        public ulong LeaderId { get; set; }
        public List<PartyInvitationMemberInformations> Members { get; set; }
        public List<PartyGuestInformations> Guests { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PartyType);
            writer.WriteUTF(PartyName);
            writer.WriteVarUhLong(FromId);
            writer.WriteUTF(FromName);
            writer.WriteVarUhLong(LeaderId);
            writer.WriteShort((short) Members.Count);
            for (var membersIndex = 0; membersIndex < Members.Count; membersIndex++)
            {
                var objectToSend = Members[membersIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Guests.Count);
            for (var guestsIndex = 0; guestsIndex < Guests.Count; guestsIndex++)
            {
                var objectToSend = Guests[guestsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadByte();
            PartyName = reader.ReadUTF();
            FromId = reader.ReadVarUhLong();
            FromName = reader.ReadUTF();
            LeaderId = reader.ReadVarUhLong();
            var membersCount = reader.ReadUShort();
            Members = new List<PartyInvitationMemberInformations>();
            for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
            {
                var objectToAdd = new PartyInvitationMemberInformations();
                objectToAdd.Deserialize(reader);
                Members.Add(objectToAdd);
            }
            var guestsCount = reader.ReadUShort();
            Guests = new List<PartyGuestInformations>();
            for (var guestsIndex = 0; guestsIndex < guestsCount; guestsIndex++)
            {
                var objectToAdd = new PartyGuestInformations();
                objectToAdd.Deserialize(reader);
                Guests.Add(objectToAdd);
            }
        }
    }
}