using Cookie.API.Protocol.Network.Types.Game.Context;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameMapChangeOrientationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 946;

        public GameMapChangeOrientationMessage(ActorOrientation orientation)
        {
            Orientation = orientation;
        }

        public GameMapChangeOrientationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ActorOrientation Orientation { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Orientation.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Orientation = new ActorOrientation();
            Orientation.Deserialize(reader);
        }
    }
}