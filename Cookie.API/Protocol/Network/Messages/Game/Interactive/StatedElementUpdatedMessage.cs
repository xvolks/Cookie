using Cookie.API.Protocol.Network.Types.Game.Interactive;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    public class StatedElementUpdatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5709;

        public StatedElementUpdatedMessage(StatedElement statedElement)
        {
            StatedElement = statedElement;
        }

        public StatedElementUpdatedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public StatedElement StatedElement { get; set; }

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