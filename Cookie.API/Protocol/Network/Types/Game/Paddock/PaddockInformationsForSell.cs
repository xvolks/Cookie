using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    public class PaddockInformationsForSell : NetworkType
    {
        public const ushort ProtocolId = 222;

        public PaddockInformationsForSell(string guildOwner, short worldX, short worldY, ushort subAreaId,
            sbyte nbMount, sbyte nbObject, ulong price)
        {
            GuildOwner = guildOwner;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            NbMount = nbMount;
            NbObject = nbObject;
            Price = price;
        }

        public PaddockInformationsForSell()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string GuildOwner { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public ushort SubAreaId { get; set; }
        public sbyte NbMount { get; set; }
        public sbyte NbObject { get; set; }
        public ulong Price { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(GuildOwner);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteSByte(NbMount);
            writer.WriteSByte(NbObject);
            writer.WriteVarUhLong(Price);
        }

        public override void Deserialize(IDataReader reader)
        {
            GuildOwner = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadVarUhShort();
            NbMount = reader.ReadSByte();
            NbObject = reader.ReadSByte();
            Price = reader.ReadVarUhLong();
        }
    }
}