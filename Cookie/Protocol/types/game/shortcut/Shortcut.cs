using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class Shortcut : NetworkType
    {
        public const short ProtocolId = 369;
        public override short TypeId { get { return ProtocolId; } }

        public byte Slot = 0;

        public Shortcut()
        {
        }

        public Shortcut(
            byte slot
        )
        {
            Slot = slot;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Slot);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Slot = reader.ReadByte();
        }
    }
}