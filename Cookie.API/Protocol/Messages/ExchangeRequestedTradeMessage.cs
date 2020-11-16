using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
    {
        public new const ushort ProtocolId = 5523;

        public override ushort MessageID => ProtocolId;

        public ulong Source { get; set; }
        public ulong Target { get; set; }
        public ExchangeRequestedTradeMessage() { }

        public ExchangeRequestedTradeMessage( ulong Source, ulong Target ){
            this.Source = Source;
            this.Target = Target;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Source);
            writer.WriteVarUhLong(Target);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Source = reader.ReadVarUhLong();
            Target = reader.ReadVarUhLong();
        }
    }
}
