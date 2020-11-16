using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ShortcutBarSwapRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6230;

        public override ushort MessageID => ProtocolId;

        public sbyte BarType { get; set; }
        public sbyte FirstSlot { get; set; }
        public sbyte SecondSlot { get; set; }
        public ShortcutBarSwapRequestMessage() { }

        public ShortcutBarSwapRequestMessage( sbyte BarType, sbyte FirstSlot, sbyte SecondSlot ){
            this.BarType = BarType;
            this.FirstSlot = FirstSlot;
            this.SecondSlot = SecondSlot;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(BarType);
            writer.WriteSByte(FirstSlot);
            writer.WriteSByte(SecondSlot);
        }

        public override void Deserialize(IDataReader reader)
        {
            BarType = reader.ReadSByte();
            FirstSlot = reader.ReadSByte();
            SecondSlot = reader.ReadSByte();
        }
    }
}
