using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class OnConnectionEventMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5726;

        public override ushort MessageID => ProtocolId;

        public sbyte EventType { get; set; }
        public OnConnectionEventMessage() { }

        public OnConnectionEventMessage( sbyte EventType ){
            this.EventType = EventType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(EventType);
        }

        public override void Deserialize(IDataReader reader)
        {
            EventType = reader.ReadSByte();
        }
    }
}
