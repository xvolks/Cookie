using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HavenBagFurnitureInformation : NetworkType
    {
        public const ushort ProtocolId = 498;

        public override ushort TypeID => ProtocolId;

        public ushort CellId { get; set; }
        public int FunitureId { get; set; }
        public sbyte Orientation { get; set; }
        public HavenBagFurnitureInformation() { }

        public HavenBagFurnitureInformation( ushort CellId, int FunitureId, sbyte Orientation ){
            this.CellId = CellId;
            this.FunitureId = FunitureId;
            this.Orientation = Orientation;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteInt(FunitureId);
            writer.WriteSByte(Orientation);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            FunitureId = reader.ReadInt();
            Orientation = reader.ReadSByte();
        }
    }
}
