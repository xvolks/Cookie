using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MountHarnessColorsUpdateRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6697;
        public override uint MessageID { get { return ProtocolId; } }

        public bool UseHarnessColors = false;

        public MountHarnessColorsUpdateRequestMessage()
        {
        }

        public MountHarnessColorsUpdateRequestMessage(
            bool useHarnessColors
        )
        {
            UseHarnessColors = useHarnessColors;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(UseHarnessColors);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            UseHarnessColors = reader.ReadBoolean();
        }
    }
}