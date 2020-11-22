using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterNameSuggestionSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5544;

        public override ushort MessageID => ProtocolId;

        public string Suggestion { get; set; }
        public CharacterNameSuggestionSuccessMessage() { }

        public CharacterNameSuggestionSuccessMessage( string Suggestion ){
            this.Suggestion = Suggestion;
        }

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
