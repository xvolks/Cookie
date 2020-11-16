using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockSellBuyDialogMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6018;

        public override ushort MessageID => ProtocolId;

        public bool Bsell { get; set; }
        public uint OwnerId { get; set; }
        public ulong Price { get; set; }
        public PaddockSellBuyDialogMessage() { }

        public PaddockSellBuyDialogMessage( bool Bsell, uint OwnerId, ulong Price ){
            this.Bsell = Bsell;
            this.OwnerId = OwnerId;
            this.Price = Price;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Bsell);
            writer.WriteVarUhInt(OwnerId);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            Bsell = reader.ReadBoolean();
            OwnerId = reader.ReadVarUhInt();
            Price = reader.ReadVarUhLong();
        }
    }
}
