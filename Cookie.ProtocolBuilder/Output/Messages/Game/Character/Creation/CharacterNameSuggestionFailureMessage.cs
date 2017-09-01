namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    using Utils.IO;

    public class CharacterNameSuggestionFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 164;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public CharacterNameSuggestionFailureMessage(byte reason)
        {
            Reason = reason;
        }

        public CharacterNameSuggestionFailureMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
