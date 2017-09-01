using Cookie.API.Protocol.Network.Types.Game.Friend;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5924;

        public FriendUpdateMessage(FriendInformations friendUpdated)
        {
            FriendUpdated = friendUpdated;
        }

        public FriendUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public FriendInformations FriendUpdated { get; set; }

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