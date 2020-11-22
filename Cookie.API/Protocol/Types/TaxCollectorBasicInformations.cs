using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TaxCollectorBasicInformations : NetworkType
    {
        public const ushort ProtocolId = 96;

        public override ushort TypeID => ProtocolId;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public TaxCollectorBasicInformations() { }

        public TaxCollectorBasicInformations( ushort FirstNameId, ushort LastNameId, short WorldX, short WorldY, double MapId, ushort SubAreaId ){
            this.FirstNameId = FirstNameId;
            this.LastNameId = LastNameId;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}
