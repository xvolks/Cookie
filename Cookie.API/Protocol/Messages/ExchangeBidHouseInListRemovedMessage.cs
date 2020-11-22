using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5950;

        public override ushort MessageID => ProtocolId;

        public int ItemUID { get; set; }
        public ExchangeBidHouseInListRemovedMessage() { }

        public ExchangeBidHouseInListRemovedMessage( int ItemUID ){
            this.ItemUID = ItemUID;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ItemUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemUID = reader.ReadInt();
        }
    }
}
