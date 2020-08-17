using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    public class AbstractCharacterToRefurbishInformation : AbstractCharacterInformation
    {
        public new const ushort ProtocolId = 475;

        public AbstractCharacterToRefurbishInformation(List<int> colors, uint cosmeticId)
        {
            Colors = colors;
            CosmeticId = cosmeticId;
        }

        public AbstractCharacterToRefurbishInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<int> Colors { get; set; }
        public uint CosmeticId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Colors.Count);
            for (var colorsIndex = 0; colorsIndex < Colors.Count; colorsIndex++)
                writer.WriteInt(Colors[colorsIndex]);
            writer.WriteVarUhInt(CosmeticId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var colorsCount = reader.ReadUShort();
            Colors = new List<int>();
            for (var colorsIndex = 0; colorsIndex < colorsCount; colorsIndex++)
                Colors.Add(reader.ReadInt());
            CosmeticId = reader.ReadVarUhInt();
        }
    }
}