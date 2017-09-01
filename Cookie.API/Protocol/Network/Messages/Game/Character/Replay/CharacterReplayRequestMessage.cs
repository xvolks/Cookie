using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Replay
{
    public class CharacterReplayRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 167;

        public CharacterReplayRequestMessage(ulong characterId)
        {
            CharacterId = characterId;
        }

        public CharacterReplayRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong CharacterId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharacterId = reader.ReadVarUhLong();
        }
    }
}