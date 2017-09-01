namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5605;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }

        public FriendJoinRequestMessage(string name)
        {
            Name = name;
        }

        public FriendJoinRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }

    }
}
