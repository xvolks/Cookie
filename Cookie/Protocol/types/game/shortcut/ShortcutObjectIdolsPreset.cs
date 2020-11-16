using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ShortcutObjectIdolsPreset : ShortcutObject
    {
        public new const short ProtocolId = 492;
        public override short TypeId { get { return ProtocolId; } }

        public short PresetId = 0;

        public ShortcutObjectIdolsPreset(): base()
        {
        }

        public ShortcutObjectIdolsPreset(
            byte slot,
            short presetId
        ): base(
            slot
        )
        {
            PresetId = presetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(PresetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PresetId = reader.ReadShort();
        }
    }
}