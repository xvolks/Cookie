using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5605;

        public FriendJoinRequestMessage(string name)
        {
            Name = name;
        }

        public FriendJoinRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }

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