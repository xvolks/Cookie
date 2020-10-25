using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NumericWhoIsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6297;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;
        public int AccountId = 0;

        public NumericWhoIsMessage()
        {
        }

        public NumericWhoIsMessage(
            long playerId,
            int accountId
        )
        {
            PlayerId = playerId;
            AccountId = accountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
            AccountId = reader.ReadInt();
        }
    }
}