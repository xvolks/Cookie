using Cookie.API.Protocol.Network.Types.Game.Friend;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5599;

        public FriendAddedMessage(FriendInformations friendAdded)
        {
            FriendAdded = friendAdded;
        }

        public FriendAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public FriendInformations FriendAdded { get; set; }

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