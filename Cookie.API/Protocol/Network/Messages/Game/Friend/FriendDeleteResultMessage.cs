using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendDeleteResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5601;

        public FriendDeleteResultMessage(bool success, string name)
        {
            Success = success;
            Name = name;
        }

        public FriendDeleteResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Success);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Success = reader.ReadBoolean();
            Name = reader.ReadUTF();
        }
    }
}