using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PresetsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6750;
        public override uint MessageID { get { return ProtocolId; } }

        public List<Preset> Presets;

        public PresetsMessage()
        {
        }

        public PresetsMessage(
            List<Preset> presets
        )
        {
            Presets = presets;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Presets.Count());
            foreach (var current in Presets)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
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