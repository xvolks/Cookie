namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyRefuseInvitationMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5582;
        public override ushort MessageID => ProtocolId;

        public PartyRefuseInvitationMessage() { }

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
