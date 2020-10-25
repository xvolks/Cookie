using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightNewRoundMessage : NetworkMessage
    {
        public const uint ProtocolId = 6239;
        public override uint MessageID { get { return ProtocolId; } }

        public int RoundNumber = 0;

        public GameFightNewRoundMessage()
        {
        }

        public GameFightNewRoundMessage(
            int roundNumber
        )
        {
            RoundNumber = roundNumber;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(RoundNumber);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RoundNumber = reader.ReadVarInt();
        }
    }
}