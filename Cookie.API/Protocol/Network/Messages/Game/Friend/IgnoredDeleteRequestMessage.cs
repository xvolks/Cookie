using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class IgnoredDeleteRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5680;

        public IgnoredDeleteRequestMessage(int accountId, bool session)
        {
            AccountId = accountId;
            Session = session;
        }

        public IgnoredDeleteRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int AccountId { get; set; }
        public bool Session { get; set; }

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