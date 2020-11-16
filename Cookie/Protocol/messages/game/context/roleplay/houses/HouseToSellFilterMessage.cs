using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseToSellFilterMessage : NetworkMessage
    {
        public const uint ProtocolId = 6137;
        public override uint MessageID { get { return ProtocolId; } }

        public int AreaId = 0;
        public byte AtLeastNbRoom = 0;
        public byte AtLeastNbChest = 0;
        public short SkillRequested = 0;
        public long MaxPrice = 0;
        public byte OrderBy = 0;

        public HouseToSellFilterMessage()
        {
        }

        public HouseToSellFilterMessage(
            int areaId,
            byte atLeastNbRoom,
            byte atLeastNbChest,
            short skillRequested,
            long maxPrice,
            byte orderBy
        )
        {
            AreaId = areaId;
            AtLeastNbRoom = atLeastNbRoom;
            AtLeastNbChest = atLeastNbChest;
            SkillRequested = skillRequested;
            MaxPrice = maxPrice;
            OrderBy = orderBy;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteByte(AtLeastNbRoom);
            writer.WriteByte(AtLeastNbChest);
            writer.WriteVarShort(SkillRequested);
            writer.WriteVarLong(MaxPrice);
            writer.WriteByte(OrderBy);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbRoom = reader.ReadByte();
            AtLeastNbChest = reader.ReadByte();
            SkillRequested = reader.ReadVarShort();
            MaxPrice = reader.ReadVarLong();
            OrderBy = reader.ReadByte();
        }
    }
}