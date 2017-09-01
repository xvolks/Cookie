using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightNewRoundMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6239;

        public GameFightNewRoundMessage(uint roundNumber)
        {
            RoundNumber = roundNumber;
        }

        public GameFightNewRoundMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint RoundNumber { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RoundNumber);
        }

        public override void Deserialize(IDataReader reader)
        {
            RoundNumber = reader.ReadVarUhInt();
        }
    }
}