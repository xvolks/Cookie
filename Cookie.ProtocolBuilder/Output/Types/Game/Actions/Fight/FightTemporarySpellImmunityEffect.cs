namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    using Utils.IO;

    public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 366;
        public override ushort TypeID => ProtocolId;
        public int ImmuneSpellId { get; set; }

        public FightTemporarySpellImmunityEffect(int immuneSpellId)
        {
            ImmuneSpellId = immuneSpellId;
        }

        public FightTemporarySpellImmunityEffect() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ImmuneSpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ImmuneSpellId = reader.ReadInt();
        }

    }
}
