using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockInformationsForSell : NetworkType
    {
        public const short ProtocolId = 222;
        public override short TypeId { get { return ProtocolId; } }

        public string GuildOwner;
        public short WorldX = 0;
        public short WorldY = 0;
        public short SubAreaId = 0;
        public byte NbMount = 0;
        public byte NbObject = 0;
        public long Price = 0;

        public PaddockInformationsForSell()
        {
        }

        public PaddockInformationsForSell(
            string guildOwner,
            short worldX,
            short worldY,
            short subAreaId,
            byte nbMount,
            byte nbObject,
            long price
        )
        {
            GuildOwner = guildOwner;
            WorldX = worldX;
            WorldY = worldY;
            SubAreaId = subAreaId;
            NbMount = nbMount;
            NbObject = nbObject;
            Price = price;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(GuildOwner);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteVarShort(SubAreaId);
            writer.WriteByte(NbMount);
            writer.WriteByte(NbObject);
            writer.WriteVarLong(Price);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildOwner = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            SubAreaId = reader.ReadVarShort();
            NbMount = reader.ReadByte();
            NbObject = reader.ReadByte();
            Price = reader.ReadVarLong();
        }
    }
}