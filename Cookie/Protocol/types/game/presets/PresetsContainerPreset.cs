using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PresetsContainerPreset : Preset
    {
        public new const short ProtocolId = 520;
        public override short TypeId { get { return ProtocolId; } }

        public List<Preset> Presets;

        public PresetsContainerPreset(): base()
        {
        }

        public PresetsContainerPreset(
            short id_,
            List<Preset> presets
        ): base(
            id_
        )
        {
            Presets = presets;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Presets.Count());
            foreach (var current in Presets)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countPresets = reader.ReadShort();
            Presets = new List<Preset>();
            for (short i = 0; i < countPresets; i++)
            {
                var presetstypeId = reader.ReadShort();
                Preset type = new Preset();
                type.Deserialize(reader);
                Presets.Add(type);
            }
        }
    }
}