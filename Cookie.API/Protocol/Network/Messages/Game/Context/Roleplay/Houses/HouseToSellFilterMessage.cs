using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    public class HouseToSellFilterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6137;

        public HouseToSellFilterMessage(int areaId, byte atLeastNbRoom, byte atLeastNbChest, ushort skillRequested,
            ulong maxPrice)
        {
            AreaId = areaId;
            AtLeastNbRoom = atLeastNbRoom;
            AtLeastNbChest = atLeastNbChest;
            SkillRequested = skillRequested;
            MaxPrice = maxPrice;
        }

        public HouseToSellFilterMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int AreaId { get; set; }
        public byte AtLeastNbRoom { get; set; }
        public byte AtLeastNbChest { get; set; }
        public ushort SkillRequested { get; set; }
        public ulong MaxPrice { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AreaId);
            writer.WriteByte(AtLeastNbRoom);
            writer.WriteByte(AtLeastNbChest);
            writer.WriteVarUhShort(SkillRequested);
            writer.WriteVarUhLong(MaxPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            AreaId = reader.ReadInt();
            AtLeastNbRoom = reader.ReadByte();
            AtLeastNbChest = reader.ReadByte();
            SkillRequested = reader.ReadVarUhShort();
            MaxPrice = reader.ReadVarUhLong();
        }
    }
}