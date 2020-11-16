using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicTimeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 175;

        public override ushort MessageID => ProtocolId;

        public double Timestamp { get; set; }
        public short TimezoneOffset { get; set; }
        public BasicTimeMessage() { }

        public BasicTimeMessage( double Timestamp, short TimezoneOffset ){
            this.Timestamp = Timestamp;
            this.TimezoneOffset = TimezoneOffset;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Timestamp);
            writer.WriteShort(TimezoneOffset);
        }

        public override void Deserialize(IDataReader reader)
        {
            Timestamp = reader.ReadDouble();
            TimezoneOffset = reader.ReadShort();
        }
    }
}
