using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NumericWhoIsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6298;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public NumericWhoIsRequestMessage()
        {
        }

        public NumericWhoIsRequestMessage(
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