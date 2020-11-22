using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PaddockInformationsForSell : NetworkType
    {
        public const ushort ProtocolId = 222;

        public override ushort TypeID => ProtocolId;

        public string GuildOwner { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public ushort SubAreaId { get; set; }
        public sbyte NbMount { get; set; }
        public sbyte NbObject { get; set; }
        public ulong Price { get; set; }
        public PaddockInformationsForSell() { }

        public PaddockInformationsForSell( string GuildOwner, short WorldX, short WorldY, ushort SubAreaId, sbyte NbMount, sbyte NbObject, ulong Price ){
            this.GuildOwner = GuildOwner;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.SubAreaId = SubAreaId;
            this.NbMount = NbMount;
            this.NbObject = NbObject;
            this.Price = Price;
        }

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
