namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Types.Game.Data.Items;
    using Types.Game.Inventory.Preset;
    using Types.Game.Inventory.Preset;
    using System.Collections.Generic;
    using Utils.IO;

    public class InventoryContentAndPresetMessage : InventoryContentMessage
    {
        public new const ushort ProtocolId = 6162;
        public override ushort MessageID => ProtocolId;
        public List<Preset> Presets { get; set; }
        public List<IdolsPreset> IdolsPresets { get; set; }

        public InventoryContentAndPresetMessage(List<Preset> presets, List<IdolsPreset> idolsPresets)
        {
            Presets = presets;
            IdolsPresets = idolsPresets;
        }

        public InventoryContentAndPresetMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Presets.Count);
            for (var presetsIndex = 0; presetsIndex < Presets.Count; presetsIndex++)
            {
                var objectToSend = Presets[presetsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short)IdolsPresets.Count);
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
            Presets = new List<Preset>();
            for (var presetsIndex = 0; presetsIndex < presetsCount; presetsIndex++)
            {
                var objectToAdd = new Preset();
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
