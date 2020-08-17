namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
    {
        public new const ushort ProtocolId = 6283;
        public override ushort MessageID => ProtocolId;

        public PartyInvitationArenaRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
