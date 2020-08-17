using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 366;

        public FightTemporarySpellImmunityEffect(int immuneSpellId)
        {
            ImmuneSpellId = immuneSpellId;
        }

        public FightTemporarySpellImmunityEffect()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int ImmuneSpellId { get; set; }

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