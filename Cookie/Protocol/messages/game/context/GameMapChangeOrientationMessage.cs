using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapChangeOrientationMessage : NetworkMessage
    {
        public const uint ProtocolId = 946;
        public override uint MessageID { get { return ProtocolId; } }

        public ActorOrientation Orientation;

        public GameMapChangeOrientationMessage()
        {
        }

        public GameMapChangeOrientationMessage(
            ActorOrientation orientation
        )
        {
            Orientation = orientation;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Orientation.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Orientation = new ActorOrientation();
            Orientation.Deserialize(reader);
        }
    }
}