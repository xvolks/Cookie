namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    using Types.Game.Idol;
    using Utils.IO;

    public class IdolPartyRefreshMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6583;
        public override ushort MessageID => ProtocolId;
        public PartyIdol PartyIdol { get; set; }

        public IdolPartyRefreshMessage(PartyIdol partyIdol)
        {
            PartyIdol = partyIdol;
        }

        public IdolPartyRefreshMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            PartyIdol.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PartyIdol = new PartyIdol();
            PartyIdol.Deserialize(reader);
        }

    }
}
