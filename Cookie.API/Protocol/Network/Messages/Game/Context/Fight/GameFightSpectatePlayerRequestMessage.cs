using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightSpectatePlayerRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6474;

        public GameFightSpectatePlayerRequestMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public GameFightSpectatePlayerRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

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