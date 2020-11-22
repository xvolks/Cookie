using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareSubscribeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6666;

        public override ushort MessageID => ProtocolId;

        public double DareId { get; set; }
        public bool Subscribe { get; set; }
        public DareSubscribeRequestMessage() { }

        public DareSubscribeRequestMessage( double DareId, bool Subscribe ){
            this.DareId = DareId;
            this.Subscribe = Subscribe;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            writer.WriteBoolean(Subscribe);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Subscribe = reader.ReadBoolean();
        }
    }
}
