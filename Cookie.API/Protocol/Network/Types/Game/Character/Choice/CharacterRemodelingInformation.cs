using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    public class CharacterRemodelingInformation : AbstractCharacterInformation
    {
        public new const ushort ProtocolId = 479;

        public CharacterRemodelingInformation(string name, sbyte breed, bool sex, ushort cosmeticId, List<int> colors)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
            Colors = colors;
        }

        public CharacterRemodelingInformation()
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
            base.Serialize(writer);
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
            base.Deserialize(reader);
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