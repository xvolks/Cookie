using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCraftCountRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6597;

        public override ushort MessageID => ProtocolId;

        public int Count { get; set; }
        public ExchangeCraftCountRequestMessage() { }

        public ExchangeCraftCountRequestMessage( int Count ){
            this.Count = Count;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(Count);
        }

        public override void Deserialize(IDataReader reader)
        {
            Count = reader.ReadVarInt();
        }
    }
}
