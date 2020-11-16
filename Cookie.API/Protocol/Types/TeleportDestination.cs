using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TeleportDestination : NetworkType
    {
        public const ushort ProtocolId = 563;

        public override ushort TypeID => ProtocolId;

        public sbyte Type { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public ushort Level { get; set; }
        public ushort Cost { get; set; }
        public TeleportDestination() { }

        public TeleportDestination( sbyte Type, double MapId, ushort SubAreaId, ushort Level, ushort Cost ){
            this.Type = Type;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.Level = Level;
            this.Cost = Cost;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(Level);
            writer.WriteVarUhShort(Cost);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            Level = reader.ReadVarUhShort();
            Cost = reader.ReadVarUhShort();
        }
    }
}
