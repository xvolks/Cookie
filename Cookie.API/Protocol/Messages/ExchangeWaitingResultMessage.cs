using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeWaitingResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5786;

        public override ushort MessageID => ProtocolId;

        public bool Bwait { get; set; }
        public ExchangeWaitingResultMessage() { }

        public ExchangeWaitingResultMessage( bool Bwait ){
            this.Bwait = Bwait;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bwait);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bwait = reader.ReadBoolean();
        }
    }
}
