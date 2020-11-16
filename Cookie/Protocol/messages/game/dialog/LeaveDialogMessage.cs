using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LeaveDialogMessage : NetworkMessage
    {
        public const uint ProtocolId = 5502;
        public override uint MessageID { get { return ProtocolId; } }

        public byte DialogType = 0;

        public LeaveDialogMessage()
        {
        }

        public LeaveDialogMessage(
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