namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyLocateMembersRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5587;
        public override ushort MessageID => ProtocolId;

        public PartyLocateMembersRequestMessage() { }

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
