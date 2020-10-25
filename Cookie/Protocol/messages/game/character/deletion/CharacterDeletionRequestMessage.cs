using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterDeletionRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 165;
        public override uint MessageID { get { return ProtocolId; } }

        public long CharacterId = 0;
        public string SecretAnswerHash;

        public CharacterDeletionRequestMessage()
        {
        }

        public CharacterDeletionRequestMessage(
            long characterId,
            string secretAnswerHash
        )
        {
            CharacterId = characterId;
            SecretAnswerHash = secretAnswerHash;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(CharacterId);
            writer.WriteUTF(SecretAnswerHash);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CharacterId = reader.ReadVarLong();
            SecretAnswerHash = reader.ReadUTF();
        }
    }
}