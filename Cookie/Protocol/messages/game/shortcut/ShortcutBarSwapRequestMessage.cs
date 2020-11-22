using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ShortcutBarSwapRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6230;
        public override uint MessageID { get { return ProtocolId; } }

        public byte BarType = 0;
        public byte FirstSlot = 0;
        public byte SecondSlot = 0;

        public ShortcutBarSwapRequestMessage()
        {
        }

        public ShortcutBarSwapRequestMessage(
            byte barType,
            byte firstSlot,
            byte secondSlot
        )
        {
            BarType = barType;
            FirstSlot = firstSlot;
            SecondSlot = secondSlot;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(BarType);
            writer.WriteByte(FirstSlot);
            writer.WriteByte(SecondSlot);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BarType = reader.ReadByte();
            FirstSlot = reader.ReadByte();
            SecondSlot = reader.ReadByte();
        }
    }
}