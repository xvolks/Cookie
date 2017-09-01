using Cookie.API.Protocol.Network.Types.Game.Interactive;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    public class InteractiveElementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5708;

        public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
        {
            InteractiveElement = interactiveElement;
        }

        public InteractiveElementUpdatedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public InteractiveElement InteractiveElement { get; set; }

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