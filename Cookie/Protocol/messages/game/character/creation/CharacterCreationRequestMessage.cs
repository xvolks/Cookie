using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 160;
        public override uint MessageID { get { return ProtocolId; } }

        public string Name;
        public byte Breed = 0;
        public bool Sex = false;
        public List<int> Colors;
        public short CosmeticId = 0;

        public CharacterCreationRequestMessage()
        {
        }

        public CharacterCreationRequestMessage(
            string name,
            byte breed,
            bool sex,
            List<int> colors,
            short cosmeticId
        )
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            Colors = colors;
            CosmeticId = cosmeticId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Name);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
            foreach (var current in Colors)
            {
                writer.WriteInt(current);
            }
            writer.WriteVarShort(CosmeticId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
            Colors = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                Colors.Add(reader.ReadInt());
            }
            CosmeticId = reader.ReadVarShort();
        }
    }
}