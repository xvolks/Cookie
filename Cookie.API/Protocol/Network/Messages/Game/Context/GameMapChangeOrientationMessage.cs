namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Context;
    using Utils.IO;

    public class GameMapChangeOrientationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 946;
        public override ushort MessageID => ProtocolId;
        public ActorOrientation Orientation { get; set; }

        public GameMapChangeOrientationMessage(ActorOrientation orientation)
        {
            Orientation = orientation;
        }

        public GameMapChangeOrientationMessage() { }

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
