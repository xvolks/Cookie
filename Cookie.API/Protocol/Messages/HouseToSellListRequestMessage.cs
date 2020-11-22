using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseToSellListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6139;

        public override ushort MessageID => ProtocolId;

        public ushort PageIndex { get; set; }
        public HouseToSellListRequestMessage() { }

        public HouseToSellListRequestMessage( ushort PageIndex ){
            this.PageIndex = PageIndex;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(PageIndex);
        }

        public override void Deserialize(IDataReader reader)
        {
            PageIndex = reader.ReadVarUhShort();
        }
    }
}
