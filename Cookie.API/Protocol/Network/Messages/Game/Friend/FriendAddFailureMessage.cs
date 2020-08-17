namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendAddFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5600;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public FriendAddFailureMessage(byte reason)
        {
            Reason = reason;
        }

        public FriendAddFailureMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
