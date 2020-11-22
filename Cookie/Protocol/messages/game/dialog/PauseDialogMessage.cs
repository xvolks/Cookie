using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PauseDialogMessage : NetworkMessage
    {
        public const uint ProtocolId = 6012;
        public override uint MessageID { get { return ProtocolId; } }

        public byte DialogType = 0;

        public PauseDialogMessage()
        {
        }

        public PauseDialogMessage(
            byte dialogType
        )
        {
            DialogType = dialogType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(DialogType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DialogType = reader.ReadByte();
        }
    }
}