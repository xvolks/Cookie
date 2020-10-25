using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ShortcutBarRemoveRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6228;
        public override uint MessageID { get { return ProtocolId; } }

        public byte BarType = 0;
        public byte Slot = 0;

        public ShortcutBarRemoveRequestMessage()
        {
        }

        public ShortcutBarRemoveRequestMessage(
            byte barType,
            byte slot
        )
        {
            BarType = barType;
            Slot = slot;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(BarType);
            writer.WriteByte(Slot);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BarType = reader.ReadByte();
            Slot = reader.ReadByte();
        }
    }
}