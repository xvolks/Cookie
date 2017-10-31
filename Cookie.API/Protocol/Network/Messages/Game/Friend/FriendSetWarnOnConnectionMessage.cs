namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendSetWarnOnConnectionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5602;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public FriendSetWarnOnConnectionMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendSetWarnOnConnectionMessage() { }

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
