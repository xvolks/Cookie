using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PresetSavedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6763;
        public override uint MessageID { get { return ProtocolId; } }

        public short PresetId = 0;
        public Preset Preset_;

        public PresetSavedMessage()
        {
        }

        public PresetSavedMessage(
            short presetId,
            Preset preset_
        )
        {
            PresetId = presetId;
            Preset_ = preset_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(PresetId);
            writer.WriteShort(Preset_.TypeId);
            Preset_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PresetId = reader.ReadShort();
            var preset_TypeId = reader.ReadShort();
            Preset_ = new Preset();
            Preset_.Deserialize(reader);
        }
    }
}