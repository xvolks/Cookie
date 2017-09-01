using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    public class CharacterNameSuggestionFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 164;

        public CharacterNameSuggestionFailureMessage(byte reason)
        {
            Reason = reason;
        }

        public CharacterNameSuggestionFailureMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

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