using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseKickIndoorMerchantRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5661;

        public override ushort MessageID => ProtocolId;

        public ushort CellId { get; set; }
        public HouseKickIndoorMerchantRequestMessage() { }

        public HouseKickIndoorMerchantRequestMessage( ushort CellId ){
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
        }
    }
}
