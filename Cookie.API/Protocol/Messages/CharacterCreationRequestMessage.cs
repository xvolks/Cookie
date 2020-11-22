using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 160;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public List<int> Colors { get; set; }
        public ushort CosmeticId { get; set; }
        public CharacterCreationRequestMessage() { }

        public CharacterCreationRequestMessage( string Name, sbyte Breed, bool Sex, List<int> Colors, ushort CosmeticId ){
            this.Name = Name;
            this.Breed = Breed;
            this.Sex = Sex;
            this.Colors = Colors;
            this.CosmeticId = CosmeticId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
			if(Colors.Count > 5) throw new System.Exception("Colors Count returned greater than 5");
			foreach (var x in Colors)
			{
				writer.WriteInt(x);
			}
            writer.WriteVarUhShort(CosmeticId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            var ColorsCount = 5;
            Colors = new List<int>();
            for (var i = 0; i < ColorsCount; i++)
            {
                Colors.Add(reader.ReadInt());
            }
            CosmeticId = reader.ReadVarUhShort();
        }
    }
}
