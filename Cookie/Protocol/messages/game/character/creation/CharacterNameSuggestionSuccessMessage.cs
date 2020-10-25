using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterNameSuggestionSuccessMessage : NetworkMessage
    {
        public const uint ProtocolId = 5544;
        public override uint MessageID { get { return ProtocolId; } }

        public string Suggestion;

        public CharacterNameSuggestionSuccessMessage()
        {
        }

        public CharacterNameSuggestionSuccessMessage(
            string suggestion
        )
        {
            Suggestion = suggestion;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Suggestion);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Suggestion = reader.ReadUTF();
        }
    }
}