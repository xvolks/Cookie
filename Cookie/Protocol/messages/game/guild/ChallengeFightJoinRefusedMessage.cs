using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChallengeFightJoinRefusedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5908;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;
        public byte Reason = 0;

        public ChallengeFightJoinRefusedMessage()
        {
        }

        public ChallengeFightJoinRefusedMessage(
            long playerId,
            byte reason
        )
        {
            PlayerId = playerId;
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
            Reason = reader.ReadByte();
        }
    }
}