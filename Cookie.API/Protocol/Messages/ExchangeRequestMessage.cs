using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5505;

        public override ushort MessageID => ProtocolId;

        public sbyte ExchangeType { get; set; }
        public ExchangeRequestMessage() { }

        public ExchangeRequestMessage( sbyte ExchangeType ){
            this.ExchangeType = ExchangeType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ExchangeType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ExchangeType = reader.ReadSByte();
        }
    }
}
