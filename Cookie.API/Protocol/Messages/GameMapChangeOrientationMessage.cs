using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameMapChangeOrientationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 946;

        public override ushort MessageID => ProtocolId;

        public ActorOrientation Orientation { get; set; }
        public GameMapChangeOrientationMessage() { }

        public GameMapChangeOrientationMessage( ActorOrientation Orientation ){
            this.Orientation = Orientation;
        }

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
