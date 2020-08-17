using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class NumericWhoIsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6297;

        public NumericWhoIsMessage(ulong playerId, int accountId)
        {
            PlayerId = playerId;
            AccountId = accountId;
        }

        public NumericWhoIsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            AccountId = reader.ReadInt();
        }
    }
}