using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MoodSmileyUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6388;
        public override uint MessageID { get { return ProtocolId; } }

        public int AccountId = 0;
        public long PlayerId = 0;
        public short SmileyId = 0;

        public MoodSmileyUpdateMessage()
        {
        }

        public MoodSmileyUpdateMessage(
            int accountId,
            long playerId,
            short smileyId
        )
        {
            AccountId = accountId;
            PlayerId = playerId;
            SmileyId = smileyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteVarLong(PlayerId);
            writer.WriteVarShort(SmileyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadVarLong();
            SmileyId = reader.ReadVarShort();
        }
    }
}