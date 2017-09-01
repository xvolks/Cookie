using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyJoinMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5576;

        public PartyJoinMessage(byte partyType, ulong partyLeaderId, byte maxParticipants,
            List<PartyMemberInformations> members, List<PartyGuestInformations> guests, bool restricted,
            string partyName)
        {
            PartyType = partyType;
            PartyLeaderId = partyLeaderId;
            MaxParticipants = maxParticipants;
            Members = members;
            Guests = guests;
            Restricted = restricted;
            PartyName = partyName;
        }

        public PartyJoinMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PartyType { get; set; }
        public ulong PartyLeaderId { get; set; }
        public byte MaxParticipants { get; set; }
        public List<PartyMemberInformations> Members { get; set; }
        public List<PartyGuestInformations> Guests { get; set; }
        public bool Restricted { get; set; }
        public string PartyName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PartyType);
            writer.WriteVarUhLong(PartyLeaderId);
            writer.WriteByte(MaxParticipants);
            writer.WriteShort((short) Members.Count);
            for (var membersIndex = 0; membersIndex < Members.Count; membersIndex++)
            {
                var objectToSend = Members[membersIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Guests.Count);
            for (var guestsIndex = 0; guestsIndex < Guests.Count; guestsIndex++)
            {
                var objectToSend = Guests[guestsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteBoolean(Restricted);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadByte();
            PartyLeaderId = reader.ReadVarUhLong();
            MaxParticipants = reader.ReadByte();
            var membersCount = reader.ReadUShort();
            Members = new List<PartyMemberInformations>();
            for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadUShort());
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
            Restricted = reader.ReadBoolean();
            PartyName = reader.ReadUTF();
        }
    }
}