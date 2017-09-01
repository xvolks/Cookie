namespace Cookie.API.Protocol.Network.Types.Game.Guild
{
    using Utils.IO;

    public class GuildEmblem : NetworkType
    {
        public const ushort ProtocolId = 87;
        public override ushort TypeID => ProtocolId;
        public ushort SymbolShape { get; set; }
        public int SymbolColor { get; set; }
        public byte BackgroundShape { get; set; }
        public int BackgroundColor { get; set; }

        public GuildEmblem(ushort symbolShape, int symbolColor, byte backgroundShape, int backgroundColor)
        {
            SymbolShape = symbolShape;
            SymbolColor = symbolColor;
            BackgroundShape = backgroundShape;
            BackgroundColor = backgroundColor;
        }

        public GuildEmblem() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SymbolShape);
            writer.WriteInt(SymbolColor);
            writer.WriteByte(BackgroundShape);
            writer.WriteInt(BackgroundColor);
        }

        public override void Deserialize(IDataReader reader)
        {
            SymbolShape = reader.ReadVarUhShort();
            SymbolColor = reader.ReadInt();
            BackgroundShape = reader.ReadByte();
            BackgroundColor = reader.ReadInt();
        }

    }
}
