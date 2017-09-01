namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 457;
        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }

        public GameFightFighterTaxCollectorLightInformations(ushort firstNameId, ushort lastNameId)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
        }

        public GameFightFighterTaxCollectorLightInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
        }

    }
}
