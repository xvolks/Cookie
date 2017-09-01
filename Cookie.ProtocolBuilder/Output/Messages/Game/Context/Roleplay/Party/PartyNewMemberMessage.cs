namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Types.Game.Context.Roleplay.Party;
    using Utils.IO;

    public class PartyNewMemberMessage : PartyUpdateMessage
    {
        public new const ushort ProtocolId = 6306;
        public override ushort MessageID => ProtocolId;

        public PartyNewMemberMessage() { }

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
