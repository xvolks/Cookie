using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6256;

        public PartyInvitationCancelledForGuestMessage(ulong cancelerId)
        {
            CancelerId = cancelerId;
        }

        public PartyInvitationCancelledForGuestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong CancelerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(CancelerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CancelerId = reader.ReadVarUhLong();
        }
    }
}