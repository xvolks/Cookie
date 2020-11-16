using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 5586;
        public override uint MessageID { get { return ProtocolId; } }

        public byte PartyType = 0;
        public string PartyName;
        public byte MaxParticipants = 0;
        public long FromId = 0;
        public string FromName;
        public long ToId = 0;

        public PartyInvitationMessage(): base()
        {
        }

        public PartyInvitationMessage(
            int partyId,
            byte partyType,
            string partyName,
            byte maxParticipants,
            long fromId,
            string fromName,
            long toId
        ): base(
            partyId
        )
        {
            PartyType = partyType;
            PartyName = partyName;
            MaxParticipants = maxParticipants;
            FromId = fromId;
            FromName = fromName;
            ToId = toId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PartyType);
            writer.WriteUTF(PartyName);
            writer.WriteByte(MaxParticipants);
            writer.WriteVarLong(FromId);
            writer.WriteUTF(FromName);
            writer.WriteVarLong(ToId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadByte();
            PartyName = reader.ReadUTF();
            MaxParticipants = reader.ReadByte();
            FromId = reader.ReadVarLong();
            FromName = reader.ReadUTF();
            ToId = reader.ReadVarLong();
        }
    }
}