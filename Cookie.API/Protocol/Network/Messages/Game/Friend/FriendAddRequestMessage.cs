namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendAddRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4004;
        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }

        public FriendAddRequestMessage(string name)
        {
            Name = name;
        }

        public FriendAddRequestMessage() { }

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
