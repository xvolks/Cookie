using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ShortcutSpell : Shortcut
    {
        public new const short ProtocolId = 368;
        public override short TypeId { get { return ProtocolId; } }

        public short SpellId = 0;

        public ShortcutSpell(): base()
        {
        }

        public ShortcutSpell(
            byte slot,
            short spellId
        ): base(
            slot
        )
        {
            SpellId = spellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(SpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SpellId = reader.ReadVarShort();
        }
    }
}