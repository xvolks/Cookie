using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseToSellFilterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6137;

        public override ushort MessageID => ProtocolId;

        public int AreaId { get; set; }
        public sbyte AtLeastNbRoom { get; set; }
        public sbyte AtLeastNbChest { get; set; }
        public ushort SkillRequested { get; set; }
        public ulong MaxPrice { get; set; }
        public sbyte OrderBy { get; set; }
        public HouseToSellFilterMessage() { }

        public HouseToSellFilterMessage( int AreaId, sbyte AtLeastNbRoom, sbyte AtLeastNbChest, ushort SkillRequested, ulong MaxPrice, sbyte OrderBy ){
            this.AreaId = AreaId;
            this.AtLeastNbRoom = AtLeastNbRoom;
            this.AtLeastNbChest = AtLeastNbChest;
            this.SkillRequested = SkillRequested;
            this.MaxPrice = MaxPrice;
            this.OrderBy = OrderBy;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteSByte(AtLeastNbRoom);
            writer.WriteSByte(AtLeastNbChest);
            writer.WriteVarUhShort(SkillRequested);
            writer.WriteVarUhLong(MaxPrice);
            writer.WriteSByte(OrderBy);
        }

        public override void Deserialize(IDataReader reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbRoom = reader.ReadSByte();
            AtLeastNbChest = reader.ReadSByte();
            SkillRequested = reader.ReadVarUhShort();
            MaxPrice = reader.ReadVarUhLong();
            OrderBy = reader.ReadSByte();
        }
    }
}
