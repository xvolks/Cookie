namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    using Types.Game.Interactive;
    using Utils.IO;

    public class InteractiveElementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5708;
        public override ushort MessageID => ProtocolId;
        public InteractiveElement InteractiveElement { get; set; }

        public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
        {
            InteractiveElement = interactiveElement;
        }

        public InteractiveElementUpdatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            InteractiveElement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            InteractiveElement = new InteractiveElement();
            InteractiveElement.Deserialize(reader);
        }

    }
}
