using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightSpectatePlayerRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6474;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public GameFightSpectatePlayerRequestMessage()
        {
        }

        public GameFightSpectatePlayerRequestMessage(
            long playerId
        )
        {
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
        }
    }
}