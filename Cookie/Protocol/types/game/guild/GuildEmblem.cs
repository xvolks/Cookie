using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildEmblem : NetworkType
    {
        public const short ProtocolId = 87;
        public override short TypeId { get { return ProtocolId; } }

        public short SymbolShape = 0;
        public int SymbolColor = 0;
        public byte BackgroundShape = 0;
        public int BackgroundColor = 0;

        public GuildEmblem()
        {
        }

        public GuildEmblem(
            short symbolShape,
            int symbolColor,
            byte backgroundShape,
            int backgroundColor
        )
        {
            SymbolShape = symbolShape;
            SymbolColor = symbolColor;
            BackgroundShape = backgroundShape;
            BackgroundColor = backgroundColor;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SymbolShape);
            writer.WriteInt(SymbolColor);
            writer.WriteByte(BackgroundShape);
            writer.WriteInt(BackgroundColor);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SymbolShape = reader.ReadVarShort();
            SymbolColor = reader.ReadInt();
            BackgroundShape = reader.ReadByte();
            BackgroundColor = reader.ReadInt();
        }
    }
}