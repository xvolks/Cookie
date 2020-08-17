namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    using Utils.IO;

    public class CharacterCanBeCreatedResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6733;
        public override ushort MessageID => ProtocolId;
        public bool YesYouCan { get; set; }

        public CharacterCanBeCreatedResultMessage(bool yesYouCan)
        {
            YesYouCan = yesYouCan;
        }

        public CharacterCanBeCreatedResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(YesYouCan);
        }

        public override void Deserialize(IDataReader reader)
        {
            YesYouCan = reader.ReadBoolean();
        }

    }
}
