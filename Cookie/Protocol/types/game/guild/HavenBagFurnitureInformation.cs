using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HavenBagFurnitureInformation : NetworkType
    {
        public const short ProtocolId = 498;
        public override short TypeId { get { return ProtocolId; } }

        public short CellId = 0;
        public int FunitureId = 0;
        public byte Orientation = 0;

        public HavenBagFurnitureInformation()
        {
        }

        public HavenBagFurnitureInformation(
            short cellId,
            int funitureId,
            byte orientation
        )
        {
            CellId = cellId;
            FunitureId = funitureId;
            Orientation = orientation;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CellId);
            writer.WriteInt(FunitureId);
            writer.WriteByte(Orientation);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellId = reader.ReadVarShort();
            FunitureId = reader.ReadInt();
            Orientation = reader.ReadByte();
        }
    }
}