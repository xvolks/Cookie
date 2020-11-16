using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ShortcutBarReplacedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6706;

        public override ushort MessageID => ProtocolId;

        public sbyte BarType { get; set; }
        public Shortcut Shortcut { get; set; }
        public ShortcutBarReplacedMessage() { }

        public ShortcutBarReplacedMessage( sbyte BarType, Shortcut Shortcut ){
            this.BarType = BarType;
            this.Shortcut = Shortcut;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(BarType);
            Shortcut.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadSByte();
            Shortcut = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Shortcut.Deserialize(reader);
        }
    }
}
