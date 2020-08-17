namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    using Utils.IO;

    public class EntityDispositionInformations : NetworkType
    {
        public const ushort ProtocolId = 60;
        public override ushort TypeID => ProtocolId;
        public short CellId { get; set; }
        public byte Direction { get; set; }

        public EntityDispositionInformations(short cellId, byte direction)
        {
            CellId = cellId;
            Direction = direction;
        }

        public EntityDispositionInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CellId);
            writer.WriteByte(Direction);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadShort();
            Direction = reader.ReadByte();
        }

    }
}
