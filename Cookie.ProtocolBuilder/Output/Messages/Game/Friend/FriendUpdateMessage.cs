namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Types.Game.Friend;
    using Utils.IO;

    public class FriendUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5924;
        public override ushort MessageID => ProtocolId;
        public FriendInformations FriendUpdated { get; set; }

        public FriendUpdateMessage(FriendInformations friendUpdated)
        {
            FriendUpdated = friendUpdated;
        }

        public FriendUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(FriendUpdated.TypeID);
            FriendUpdated.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FriendUpdated = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadUShort());
            FriendUpdated.Deserialize(reader);
        }

    }
}
