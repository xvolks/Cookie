using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterRemodelingInformation : AbstractCharacterInformation
    {
        public new const ushort ProtocolId = 479;

        public override ushort TypeID => ProtocolId;

        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort CosmeticId { get; set; }
        public List<int> Colors { get; set; }
        public CharacterRemodelingInformation() { }

        public CharacterRemodelingInformation( string Name, sbyte Breed, bool Sex, ushort CosmeticId, List<int> Colors ){
            this.Name = Name;
            this.Breed = Breed;
            this.Sex = Sex;
            this.CosmeticId = CosmeticId;
            this.Colors = Colors;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(CosmeticId);
			writer.WriteShort((short)Colors.Count);
			foreach (var x in Colors)
			{
				writer.WriteInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            CosmeticId = reader.ReadVarUhShort();
            var ColorsCount = reader.ReadShort();
            Colors = new List<int>();
            for (var i = 0; i < ColorsCount; i++)
            {
                Colors.Add(reader.ReadInt());
            }
        }
    }
}
