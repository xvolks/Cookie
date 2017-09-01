namespace Cookie.API.Protocol.Network.Messages.Game.Character.Stats
{
    using Utils.IO;

    public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
    {
        public new const ushort ProtocolId = 6076;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public ulong ObjectId { get; set; }

        public CharacterLevelUpInformationMessage(string name, ulong objectId)
        {
            Name = name;
            ObjectId = objectId;
        }

        public CharacterLevelUpInformationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            writer.WriteVarUhLong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            ObjectId = reader.ReadVarUhLong();
        }

    }
}
