namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendWarnOnConnectionStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5630;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public FriendWarnOnConnectionStateMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendWarnOnConnectionStateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }

    }
}
