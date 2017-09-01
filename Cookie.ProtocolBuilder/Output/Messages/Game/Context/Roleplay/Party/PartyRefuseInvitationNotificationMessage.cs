namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyRefuseInvitationNotificationMessage : AbstractPartyEventMessage
    {
        public new const ushort ProtocolId = 5596;
        public override ushort MessageID => ProtocolId;
        public ulong GuestId { get; set; }

        public PartyRefuseInvitationNotificationMessage(ulong guestId)
        {
            GuestId = guestId;
        }

        public PartyRefuseInvitationNotificationMessage() { }

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
