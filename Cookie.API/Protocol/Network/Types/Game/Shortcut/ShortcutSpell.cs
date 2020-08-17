using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    public class ShortcutSpell : Shortcut
    {
        public new const ushort ProtocolId = 368;

        public ShortcutSpell(ushort spellId)
        {
            SpellId = spellId;
        }

        public ShortcutSpell()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort SpellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarUhShort();
        }
    }
}