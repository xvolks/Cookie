using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangePlayerRequestMessage : ExchangeRequestMessage
    {
        public new const ushort ProtocolId = 5773;

        public override ushort MessageID => ProtocolId;

        public ulong Target { get; set; }
        public ExchangePlayerRequestMessage() { }

        public ExchangePlayerRequestMessage( ulong Target ){
            this.Target = Target;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Target);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Target = reader.ReadVarUhLong();
        }
    }
}
