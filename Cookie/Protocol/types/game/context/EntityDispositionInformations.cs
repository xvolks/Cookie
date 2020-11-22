using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class EntityDispositionInformations : NetworkType
    {
        public const short ProtocolId = 60;
        public override short TypeId { get { return ProtocolId; } }

        public short CellId = 0;
        public byte Direction = 1;

        public EntityDispositionInformations()
        {
        }

        public EntityDispositionInformations(
            short cellId,
            byte direction
        )
        {
            CellId = cellId;
            Direction = direction;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(CellId);
            writer.WriteByte(Direction);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellId = reader.ReadShort();
            Direction = reader.ReadByte();
        }
    }
}