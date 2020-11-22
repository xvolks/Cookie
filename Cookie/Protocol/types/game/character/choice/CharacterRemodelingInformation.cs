using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterRemodelingInformation : AbstractCharacterInformation
    {
        public new const short ProtocolId = 479;
        public override short TypeId { get { return ProtocolId; } }

        public string Name;
        public byte Breed = 0;
        public bool Sex = false;
        public short CosmeticId = 0;
        public List<int> Colors;

        public CharacterRemodelingInformation(): base()
        {
        }

        public CharacterRemodelingInformation(
            long id_,
            string name,
            byte breed,
            bool sex,
            short cosmeticId,
            List<int> colors
        ): base(
            id_
        )
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
            Colors = colors;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarShort(CosmeticId);
            writer.WriteShort((short)Colors.Count());
            foreach (var current in Colors)
            {
                writer.WriteInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
            CosmeticId = reader.ReadVarShort();
            var countColors = reader.ReadShort();
            Colors = new List<int>();
            for (short i = 0; i < countColors; i++)
            {
                Colors.Add(reader.ReadInt());
            }
        }
    }
}