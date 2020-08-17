namespace Cookie.API.Protocol.Network.Messages.Game.Actions
{
    using Utils.IO;

    public class GameActionNoopMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1002;
        public override ushort MessageID => ProtocolId;

        public GameActionNoopMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
