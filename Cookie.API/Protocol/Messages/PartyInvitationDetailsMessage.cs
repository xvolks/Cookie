using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyInvitationDetailsMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6263;

        public override ushort MessageID => ProtocolId;

        public sbyte PartyType { get; set; }
        public string PartyName { get; set; }
        public ulong FromId { get; set; }
        public string FromName { get; set; }
        public ulong LeaderId { get; set; }
        public List<PartyInvitationMemberInformations> Members { get; set; }
        public List<PartyGuestInformations> Guests { get; set; }
        public PartyInvitationDetailsMessage() { }

        public PartyInvitationDetailsMessage( sbyte PartyType, string PartyName, ulong FromId, string FromName, ulong LeaderId, List<PartyInvitationMemberInformations> Members, List<PartyGuestInformations> Guests ){
            this.PartyType = PartyType;
            this.PartyName = PartyName;
            this.FromId = FromId;
            this.FromName = FromName;
            this.LeaderId = LeaderId;
            this.Members = Members;
            this.Guests = Guests;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PartyType);
            writer.WriteUTF(PartyName);
            writer.WriteVarUhLong(FromId);
            writer.WriteUTF(FromName);
            writer.WriteVarUhLong(LeaderId);
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
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadSByte();
            PartyName = reader.ReadUTF();
            FromId = reader.ReadVarUhLong();
            FromName = reader.ReadUTF();
            LeaderId = reader.ReadVarUhLong();
            var MembersCount = reader.ReadShort();
            Members = new List<PartyInvitationMemberInformations>();
            for (var i = 0; i < MembersCount; i++)
            {
                PartyInvitationMemberInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
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
        }
    }
}
