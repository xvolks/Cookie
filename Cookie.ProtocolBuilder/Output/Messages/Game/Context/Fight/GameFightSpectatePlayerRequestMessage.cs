namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightSpectatePlayerRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6474;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public GameFightSpectatePlayerRequestMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public GameFightSpectatePlayerRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
