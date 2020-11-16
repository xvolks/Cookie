using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ShortcutBarRemoveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6228;

        public override ushort MessageID => ProtocolId;

        public sbyte BarType { get; set; }
        public sbyte Slot { get; set; }
        public ShortcutBarRemoveRequestMessage() { }

        public ShortcutBarRemoveRequestMessage( sbyte BarType, sbyte Slot ){
            this.BarType = BarType;
            this.Slot = Slot;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(BarType);
            writer.WriteSByte(Slot);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadSByte();
            Slot = reader.ReadSByte();
        }
    }
}
