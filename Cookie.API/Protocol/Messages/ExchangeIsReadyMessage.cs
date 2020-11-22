using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeIsReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5509;

        public override ushort MessageID => ProtocolId;

        public double Id { get; set; }
        public bool Ready { get; set; }
        public ExchangeIsReadyMessage() { }

        public ExchangeIsReadyMessage( double Id, bool Ready ){
            this.Id = Id;
            this.Ready = Ready;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
            writer.WriteBoolean(Ready);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
            Ready = reader.ReadBoolean();
        }
    }
}
