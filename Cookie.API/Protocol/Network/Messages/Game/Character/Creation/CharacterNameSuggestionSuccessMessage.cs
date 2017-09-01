using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    public class CharacterNameSuggestionSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5544;

        public CharacterNameSuggestionSuccessMessage(string suggestion)
        {
            Suggestion = suggestion;
        }

        public CharacterNameSuggestionSuccessMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Suggestion { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Suggestion);
        }

        public override void Deserialize(IDataReader reader)
        {
            Suggestion = reader.ReadUTF();
        }
    }
}