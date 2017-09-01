using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    public class RemodelingInformation : NetworkType
    {
        public const ushort ProtocolId = 480;

        public RemodelingInformation(string name, sbyte breed, bool sex, ushort cosmeticId, List<int> colors)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
            Colors = colors;
        }

        public RemodelingInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort CosmeticId { get; set; }
        public List<int> Colors { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(CosmeticId);
            writer.WriteShort((short) Colors.Count);
            for (var colorsIndex = 0; colorsIndex < Colors.Count; colorsIndex++)
                writer.WriteInt(Colors[colorsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            CosmeticId = reader.ReadVarUhShort();
            var colorsCount = reader.ReadUShort();
            Colors = new List<int>();
            for (var colorsIndex = 0; colorsIndex < colorsCount; colorsIndex++)
                Colors.Add(reader.ReadInt());
        }
    }
}