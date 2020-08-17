namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    using Types.Game.Interactive;
    using Utils.IO;

    public class StatedElementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5709;
        public override ushort MessageID => ProtocolId;
        public StatedElement StatedElement { get; set; }

        public StatedElementUpdatedMessage(StatedElement statedElement)
        {
            StatedElement = statedElement;
        }

        public StatedElementUpdatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            StatedElement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatedElement = new StatedElement();
            StatedElement.Deserialize(reader);
        }

    }
}
