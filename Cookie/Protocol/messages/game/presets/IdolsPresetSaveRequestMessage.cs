using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolsPresetSaveRequestMessage : PresetSaveRequestMessage
    {
        public new const uint ProtocolId = 6758;
        public override uint MessageID { get { return ProtocolId; } }

        public IdolsPresetSaveRequestMessage(): base()
        {
        }

        public IdolsPresetSaveRequestMessage(
            short presetId,
            byte symbolId,
            bool updateData
        ): base(
            presetId,
            symbolId,
            updateData
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}