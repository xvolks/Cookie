using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Inventory.Preset;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class InventoryContentAndPresetMessage : InventoryContentMessage
    {
        public new const ushort ProtocolId = 6162;

        public InventoryContentAndPresetMessage(List<Types.Game.Inventory.Preset.Preset> presets,
            List<IdolsPreset> idolsPresets)
        {
            Presets = presets;
            IdolsPresets = idolsPresets;
        }

        public InventoryContentAndPresetMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<Types.Game.Inventory.Preset.Preset> Presets { get; set; }
        public List<IdolsPreset> IdolsPresets { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Presets.Count);
            for (var presetsIndex = 0; presetsIndex < Presets.Count; presetsIndex++)
            {
                var objectToSend = Presets[presetsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) IdolsPresets.Count);
            for (var idolsPresetsIndex = 0; idolsPresetsIndex < IdolsPresets.Count; idolsPresetsIndex++)
            {
                var objectToSend = IdolsPresets[idolsPresetsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var presetsCount = reader.ReadUShort();
            Presets = new List<Types.Game.Inventory.Preset.Preset>();
            for (var presetsIndex = 0; presetsIndex < presetsCount; presetsIndex++)
            {
                var objectToAdd = new Types.Game.Inventory.Preset.Preset();
                objectToAdd.Deserialize(reader);
                Presets.Add(objectToAdd);
            }
            var idolsPresetsCount = reader.ReadUShort();
            IdolsPresets = new List<IdolsPreset>();
            for (var idolsPresetsIndex = 0; idolsPresetsIndex < idolsPresetsCount; idolsPresetsIndex++)
            {
                var objectToAdd = new IdolsPreset();
                objectToAdd.Deserialize(reader);
                IdolsPresets.Add(objectToAdd);
            }
        }
    }
}