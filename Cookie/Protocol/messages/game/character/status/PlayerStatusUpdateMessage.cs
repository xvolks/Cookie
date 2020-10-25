using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PlayerStatusUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6386;
        public override uint MessageID { get { return ProtocolId; } }

        public int AccountId = 0;
        public long PlayerId = 0;
        public PlayerStatus Status;

        public PlayerStatusUpdateMessage()
        {
        }

        public PlayerStatusUpdateMessage(
            int accountId,
            long playerId,
            PlayerStatus status
        )
        {
            AccountId = accountId;
            PlayerId = playerId;
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteVarLong(PlayerId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AccountId = reader.ReadInt();
            PlayerId = reader.ReadVarLong();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}