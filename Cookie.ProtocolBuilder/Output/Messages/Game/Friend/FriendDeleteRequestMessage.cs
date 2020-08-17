namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendDeleteRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5603;
        public override ushort MessageID => ProtocolId;
        public int AccountId { get; set; }

        public FriendDeleteRequestMessage(int accountId)
        {
            AccountId = accountId;
        }

        public FriendDeleteRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
        }

    }
}
