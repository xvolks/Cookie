using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AnomalyStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6831;

        public override ushort MessageID => ProtocolId;

        public bool Open { get; set; }
        public ulong ClosingTime { get; set; }
        public AnomalyStateMessage() { }

        public AnomalyStateMessage( bool Open, ulong ClosingTime ){
            this.Open = Open;
            this.ClosingTime = ClosingTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Open);
            writer.WriteVarUhLong(ClosingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Open = reader.ReadBoolean();
            ClosingTime = reader.ReadVarUhLong();
        }
    }
}
