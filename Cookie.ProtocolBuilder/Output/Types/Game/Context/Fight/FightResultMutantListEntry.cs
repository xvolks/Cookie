namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 216;
        public override ushort TypeID => ProtocolId;
        public ushort Level { get; set; }

        public FightResultMutantListEntry(ushort level)
        {
            Level = level;
        }

        public FightResultMutantListEntry() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUhShort();
        }

    }
}
