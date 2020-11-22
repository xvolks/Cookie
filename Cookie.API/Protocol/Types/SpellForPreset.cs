using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SpellForPreset : NetworkType
    {
        public const ushort ProtocolId = 557;

        public override ushort TypeID => ProtocolId;

        public ushort SpellId { get; set; }
        public List<short> Shortcuts { get; set; }
        public SpellForPreset() { }

        public SpellForPreset( ushort SpellId, List<short> Shortcuts ){
            this.SpellId = SpellId;
            this.Shortcuts = Shortcuts;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
			writer.WriteShort((short)Shortcuts.Count);
			foreach (var x in Shortcuts)
			{
				writer.WriteShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            var ShortcutsCount = reader.ReadShort();
            Shortcuts = new List<short>();
            for (var i = 0; i < ShortcutsCount; i++)
            {
                Shortcuts.Add(reader.ReadShort());
            }
        }
    }
}
