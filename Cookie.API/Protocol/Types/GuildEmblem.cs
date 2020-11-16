using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildEmblem : NetworkType
    {
        public const ushort ProtocolId = 87;

        public override ushort TypeID => ProtocolId;

        public ushort SymbolShape { get; set; }
        public int SymbolColor { get; set; }
        public sbyte BackgroundShape { get; set; }
        public int BackgroundColor { get; set; }
        public GuildEmblem() { }

        public GuildEmblem( ushort SymbolShape, int SymbolColor, sbyte BackgroundShape, int BackgroundColor ){
            this.SymbolShape = SymbolShape;
            this.SymbolColor = SymbolColor;
            this.BackgroundShape = BackgroundShape;
            this.BackgroundColor = BackgroundColor;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SymbolShape);
            writer.WriteInt(SymbolColor);
            writer.WriteSByte(BackgroundShape);
            writer.WriteInt(BackgroundColor);
        }

        public override void Deserialize(IDataReader reader)
        {
            SymbolShape = reader.ReadVarUhShort();
            SymbolColor = reader.ReadInt();
            BackgroundShape = reader.ReadSByte();
            BackgroundColor = reader.ReadInt();
        }
    }
}
