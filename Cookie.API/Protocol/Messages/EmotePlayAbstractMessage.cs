using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EmotePlayAbstractMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5690;

        public override ushort MessageID => ProtocolId;

        public byte EmoteId { get; set; }
        public double EmoteStartTime { get; set; }
        public EmotePlayAbstractMessage() { }

        public EmotePlayAbstractMessage( byte EmoteId, double EmoteStartTime ){
            this.EmoteId = EmoteId;
            this.EmoteStartTime = EmoteStartTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }
    }
}
