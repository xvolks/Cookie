namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Types.Game.Friend;
    using Utils.IO;

    public class FriendAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5599;
        public override ushort MessageID => ProtocolId;
        public FriendInformations FriendAdded { get; set; }

        public FriendAddedMessage(FriendInformations friendAdded)
        {
            FriendAdded = friendAdded;
        }

        public FriendAddedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(FriendAdded.TypeID);
            FriendAdded.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FriendAdded = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadUShort());
            FriendAdded.Deserialize(reader);
        }

    }
}
