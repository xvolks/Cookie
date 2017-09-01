namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    using Enums;
    using System.Collections.Generic;
    using Utils.IO;

    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 160;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort CosmeticId { get; set; }

        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, ushort cosmeticId)
        {
            Name = name;
            Breed = breed;
            Sex = sex;
            CosmeticId = cosmeticId;
        }

        public CharacterCreationRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(CosmeticId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            CosmeticId = reader.ReadVarUhShort();
        }

    }
}
