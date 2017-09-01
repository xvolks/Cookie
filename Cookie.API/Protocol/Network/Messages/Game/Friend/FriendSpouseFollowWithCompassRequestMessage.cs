using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendSpouseFollowWithCompassRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5606;

        public FriendSpouseFollowWithCompassRequestMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendSpouseFollowWithCompassRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

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