using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyJoinMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5576;

        public override ushort MessageID => ProtocolId;

        public sbyte PartyType { get; set; }
        public ulong PartyLeaderId { get; set; }
        public sbyte MaxParticipants { get; set; }
        public List<PartyMemberInformations> Members { get; set; }
        public List<PartyGuestInformations> Guests { get; set; }
        public bool Restricted { get; set; }
        public string PartyName { get; set; }
        public PartyJoinMessage() { }

        public PartyJoinMessage( sbyte PartyType, ulong PartyLeaderId, sbyte MaxParticipants, List<PartyMemberInformations> Members, List<PartyGuestInformations> Guests, bool Restricted, string PartyName ){
            this.PartyType = PartyType;
            this.PartyLeaderId = PartyLeaderId;
            this.MaxParticipants = MaxParticipants;
            this.Members = Members;
            this.Guests = Guests;
            this.Restricted = Restricted;
            this.PartyName = PartyName;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PartyType);
            writer.WriteVarUhLong(PartyLeaderId);
            writer.WriteSByte(MaxParticipants);
			writer.WriteShort((short)Members.Count);
			foreach (var x in Members)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Guests.Count);
			foreach (var x in Guests)
			{
				x.Serialize(writer);
			}
            writer.WriteBoolean(Restricted);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadSByte();
            PartyLeaderId = reader.ReadVarUhLong();
            MaxParticipants = reader.ReadSByte();
            var MembersCount = reader.ReadShort();
            Members = new List<PartyMemberInformations>();
            for (var i = 0; i < MembersCount; i++)
            {
                PartyMemberInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Members.Add(objectToAdd);
            }
            var GuestsCount = reader.ReadShort();
            Guests = new List<PartyGuestInformations>();
            for (var i = 0; i < GuestsCount; i++)
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
