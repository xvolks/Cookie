using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class SpellsPreset : Preset
    {
        public new const ushort ProtocolId = 519;

        public override ushort TypeID => ProtocolId;

        public List<SpellForPreset> Spells { get; set; }
        public SpellsPreset() { }

        public SpellsPreset( List<SpellForPreset> Spells ){
            this.Spells = Spells;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Spells.Count);
			foreach (var x in Spells)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var SpellsCount = reader.ReadShort();
            Spells = new List<SpellForPreset>();
            for (var i = 0; i < SpellsCount; i++)
            {
                var objectToAdd = new SpellForPreset();
                objectToAdd.Deserialize(reader);
                Spells.Add(objectToAdd);
            }
        }
    }
}
