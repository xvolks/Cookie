namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class FightResultListEntry : NetworkType
    {
        public const ushort ProtocolId = 16;
        public override ushort TypeID => ProtocolId;
        public ushort Outcome { get; set; }
        public byte Wave { get; set; }
        public FightLoot Rewards { get; set; }

        public FightResultListEntry(ushort outcome, byte wave, FightLoot rewards)
        {
            Outcome = outcome;
            Wave = wave;
            Rewards = rewards;
        }

        public FightResultListEntry() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Outcome);
            writer.WriteByte(Wave);
            Rewards.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Outcome = reader.ReadVarUhShort();
            Wave = reader.ReadByte();
            Rewards = new FightLoot();
            Rewards.Deserialize(reader);
        }

    }
}
