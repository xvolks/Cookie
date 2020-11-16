using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ShortcutBarSwapErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6226;

        public override ushort MessageID => ProtocolId;

        public sbyte Error { get; set; }
        public ShortcutBarSwapErrorMessage() { }

        public ShortcutBarSwapErrorMessage( sbyte Error ){
            this.Error = Error;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadSByte();
        }
    }
}
