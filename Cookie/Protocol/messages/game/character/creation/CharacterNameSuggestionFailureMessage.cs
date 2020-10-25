using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterNameSuggestionFailureMessage : NetworkMessage
    {
        public const uint ProtocolId = 164;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 1;

        public CharacterNameSuggestionFailureMessage()
        {
        }

        public CharacterNameSuggestionFailureMessage(
            byte reason
        )
        {
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Reason = reader.ReadByte();
        }
    }
}