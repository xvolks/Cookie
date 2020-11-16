using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeObjectMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5515;

        public override ushort MessageID => ProtocolId;

        public bool Remote { get; set; }
        public ExchangeObjectMessage() { }

        public ExchangeObjectMessage( bool Remote ){
            this.Remote = Remote;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Remote);
        }

        public override void Deserialize(IDataReader reader)
        {
            Remote = reader.ReadBoolean();
        }
    }
}
