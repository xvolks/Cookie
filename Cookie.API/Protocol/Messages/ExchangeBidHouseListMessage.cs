using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5807;

        public override ushort MessageID => ProtocolId;

        public ushort Id { get; set; }
        public ExchangeBidHouseListMessage() { }

        public ExchangeBidHouseListMessage( ushort Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
        }
    }
}
