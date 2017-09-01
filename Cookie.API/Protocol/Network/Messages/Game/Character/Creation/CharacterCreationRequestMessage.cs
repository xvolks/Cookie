using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 160;

        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, List<int> colors, ushort cosmeticId)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            Colors = colors;
            CosmeticId = cosmeticId;
        }

        public CharacterCreationRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public List<int> Colors { get; set; }
        public ushort CosmeticId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            for (var i = 0; i < 5; i++)
                writer.WriteInt(Colors[i]);
            writer.WriteVarUhShort(CosmeticId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            for (var i = 0; i < 5; i++)
                Colors[i] = reader.ReadInt();
            CosmeticId = reader.ReadVarUhShort();
        }
    }
}