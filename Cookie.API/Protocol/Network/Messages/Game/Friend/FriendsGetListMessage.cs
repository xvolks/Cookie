using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendsGetListMessage : NetworkMessage
    {
        public const uint ProtocolId = 4001;

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}