using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ShortcutSpell : Shortcut
    {
        public new const ushort ProtocolId = 368;

        public override ushort TypeID => ProtocolId;

        public ushort SpellId { get; set; }
        public ShortcutSpell() { }

        public ShortcutSpell( ushort SpellId ){
            this.SpellId = SpellId;
        }

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
