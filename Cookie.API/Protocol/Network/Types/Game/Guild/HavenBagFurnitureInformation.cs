using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild
{
    public class HavenBagFurnitureInformation : NetworkType
    {
        public const ushort ProtocolId = 498;

        public HavenBagFurnitureInformation(ushort cellId, int funitureId, byte orientation)
        {
            CellId = cellId;
            FunitureId = funitureId;
            Orientation = orientation;
        }

        public HavenBagFurnitureInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort CellId { get; set; }
        public int FunitureId { get; set; }
        public byte Orientation { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteInt(FunitureId);
            writer.WriteByte(Orientation);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            FunitureId = reader.ReadInt();
            Orientation = reader.ReadByte();
        }
    }
}