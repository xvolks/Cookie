using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightResultMutantListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 216;

        public FightResultMutantListEntry(ushort level)
        {
            Level = level;
        }

        public FightResultMutantListEntry()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Level { get; set; }

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