using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameActionMarkedCell : NetworkType
    {
        public const ushort ProtocolId = 85;

        public override ushort TypeID => ProtocolId;

        public ushort CellId { get; set; }
        public sbyte ZoneSize { get; set; }
        public int CellColor { get; set; }
        public sbyte CellsType { get; set; }
        public GameActionMarkedCell() { }

        public GameActionMarkedCell( ushort CellId, sbyte ZoneSize, int CellColor, sbyte CellsType ){
            this.CellId = CellId;
            this.ZoneSize = ZoneSize;
            this.CellColor = CellColor;
            this.CellsType = CellsType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteSByte(ZoneSize);
            writer.WriteInt(CellColor);
            writer.WriteSByte(CellsType);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            ZoneSize = reader.ReadSByte();
            CellColor = reader.ReadInt();
            CellsType = reader.ReadSByte();
        }
    }
}
