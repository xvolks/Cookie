using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStoppedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6589;

        public override ushort MessageID => ProtocolId;

        public ulong Id { get; set; }
        public ExchangeStoppedMessage() { }

        public ExchangeStoppedMessage( ulong Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhLong();
        }
    }
}
