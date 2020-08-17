namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    using Utils.IO;

    public class CharacterSelectedForceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6068;
        public override ushort MessageID => ProtocolId;
        public int ObjectId { get; set; }

        public CharacterSelectedForceMessage(int objectId)
        {
            ObjectId = objectId;
        }

        public CharacterSelectedForceMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadInt();
        }

    }
}
