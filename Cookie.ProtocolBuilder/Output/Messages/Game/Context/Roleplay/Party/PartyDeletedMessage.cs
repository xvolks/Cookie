namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyDeletedMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6261;
        public override ushort MessageID => ProtocolId;

        public PartyDeletedMessage() { }

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
