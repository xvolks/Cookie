namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class IgnoredDeleteRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5680;
        public override ushort MessageID => ProtocolId;
        public int AccountId { get; set; }
        public bool Session { get; set; }

        public IgnoredDeleteRequestMessage(int accountId, bool session)
        {
            AccountId = accountId;
            Session = session;
        }

        public IgnoredDeleteRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(AccountId);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            AccountId = reader.ReadInt();
            Session = reader.ReadBoolean();
        }

    }
}
