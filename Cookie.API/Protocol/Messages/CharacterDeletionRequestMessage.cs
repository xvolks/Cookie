using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterDeletionRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 165;

        public override ushort MessageID => ProtocolId;

        public ulong CharacterId { get; set; }
        public string SecretAnswerHash { get; set; }
        public CharacterDeletionRequestMessage() { }

        public CharacterDeletionRequestMessage( ulong CharacterId, string SecretAnswerHash ){
            this.CharacterId = CharacterId;
            this.SecretAnswerHash = SecretAnswerHash;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
            writer.WriteUTF(SecretAnswerHash);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
            SecretAnswerHash = reader.ReadUTF();
        }
    }
}
