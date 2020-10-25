using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterReplayRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 167;
        public override uint MessageID { get { return ProtocolId; } }

        public long CharacterId = 0;

        public CharacterReplayRequestMessage()
        {
        }

        public CharacterReplayRequestMessage(
            long characterId
        )
        {
            CharacterId = characterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(CharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CharacterId = reader.ReadVarLong();
        }
    }
}