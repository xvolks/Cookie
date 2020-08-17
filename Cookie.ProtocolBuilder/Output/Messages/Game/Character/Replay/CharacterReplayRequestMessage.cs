namespace Cookie.API.Protocol.Network.Messages.Game.Character.Replay
{
    using Utils.IO;

    public class CharacterReplayRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 167;
        public override ushort MessageID => ProtocolId;
        public ulong CharacterId { get; set; }

        public CharacterReplayRequestMessage(ulong characterId)
        {
            CharacterId = characterId;
        }

        public CharacterReplayRequestMessage() { }

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
