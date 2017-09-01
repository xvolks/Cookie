using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5586;

        public PartyInvitationMessage(byte partyType, string partyName, byte maxParticipants, ulong fromId,
            string fromName, ulong toId)
        {
            PartyType = partyType;
            PartyName = partyName;
            MaxParticipants = maxParticipants;
            FromId = fromId;
            FromName = fromName;
            ToId = toId;
        }

        public PartyInvitationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte PartyType { get; set; }
        public string PartyName { get; set; }
        public byte MaxParticipants { get; set; }
        public ulong FromId { get; set; }
        public string FromName { get; set; }
        public ulong ToId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PartyType);
            writer.WriteUTF(PartyName);
            writer.WriteByte(MaxParticipants);
            writer.WriteVarUhLong(FromId);
            writer.WriteUTF(FromName);
            writer.WriteVarUhLong(ToId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadByte();
            PartyName = reader.ReadUTF();
            MaxParticipants = reader.ReadByte();
            FromId = reader.ReadVarUhLong();
            FromName = reader.ReadUTF();
            ToId = reader.ReadVarUhLong();
        }
    }
}