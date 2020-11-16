using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ShortcutBarRefreshMessage : NetworkMessage
    {
        public const uint ProtocolId = 6229;
        public override uint MessageID { get { return ProtocolId; } }

        public byte BarType = 0;
        public Shortcut Shortcut_;

        public ShortcutBarRefreshMessage()
        {
        }

        public ShortcutBarRefreshMessage(
            byte barType,
            Shortcut shortcut_
        )
        {
            BarType = barType;
            Shortcut_ = shortcut_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(BarType);
            writer.WriteShort(Shortcut_.TypeId);
            Shortcut_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            BarType = reader.ReadByte();
            var shortcut_TypeId = reader.ReadShort();
            Shortcut_ = new Shortcut();
            Shortcut_.Deserialize(reader);
        }
    }
}