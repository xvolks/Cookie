using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LoginQueueStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 10;

        public override ushort MessageID => ProtocolId;

        public ushort Position { get; set; }
        public ushort Total { get; set; }
        public LoginQueueStatusMessage() { }

        public LoginQueueStatusMessage( ushort Position, ushort Total ){
            this.Position = Position;
            this.Total = Total;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUnsignedShort(Position);
            writer.WriteUnsignedShort(Total);
        }

        public override void Deserialize(IDataReader reader)
        {
            Position = reader.ReadUnsignedShort();
            Total = reader.ReadUnsignedShort();
        }
    }
}
