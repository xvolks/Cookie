namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyCancelInvitationMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6254;
        public override ushort MessageID => ProtocolId;
        public ulong GuestId { get; set; }

        public PartyCancelInvitationMessage(ulong guestId)
        {
            GuestId = guestId;
        }

        public PartyCancelInvitationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(GuestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            GuestId = reader.ReadVarUhLong();
        }

    }
}
