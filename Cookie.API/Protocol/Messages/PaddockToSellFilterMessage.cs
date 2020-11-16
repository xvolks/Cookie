using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PaddockToSellFilterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6161;

        public override ushort MessageID => ProtocolId;

        public int AreaId { get; set; }
        public sbyte AtLeastNbMount { get; set; }
        public sbyte AtLeastNbMachine { get; set; }
        public ulong MaxPrice { get; set; }
        public sbyte OrderBy { get; set; }
        public PaddockToSellFilterMessage() { }

        public PaddockToSellFilterMessage( int AreaId, sbyte AtLeastNbMount, sbyte AtLeastNbMachine, ulong MaxPrice, sbyte OrderBy ){
            this.AreaId = AreaId;
            this.AtLeastNbMount = AtLeastNbMount;
            this.AtLeastNbMachine = AtLeastNbMachine;
            this.MaxPrice = MaxPrice;
            this.OrderBy = OrderBy;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteSByte(AtLeastNbMount);
            writer.WriteSByte(AtLeastNbMachine);
            writer.WriteVarUhLong(MaxPrice);
            writer.WriteSByte(OrderBy);
        }

        public override void Deserialize(IDataReader reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbMount = reader.ReadSByte();
            AtLeastNbMachine = reader.ReadSByte();
            MaxPrice = reader.ReadVarUhLong();
            OrderBy = reader.ReadSByte();
        }
    }
}
