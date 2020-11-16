using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CurrentServerStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6525;

        public override ushort MessageID => ProtocolId;

        public sbyte Status { get; set; }
        public CurrentServerStatusUpdateMessage() { }

        public CurrentServerStatusUpdateMessage( sbyte Status ){
            this.Status = Status;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Status);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = reader.ReadSByte();
        }
    }
}
