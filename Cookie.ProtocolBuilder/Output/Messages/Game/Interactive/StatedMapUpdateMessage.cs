namespace Cookie.API.Protocol.Network.Messages.Game.Interactive
{
    using Types.Game.Interactive;
    using System.Collections.Generic;
    using Utils.IO;

    public class StatedMapUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5716;
        public override ushort MessageID => ProtocolId;
        public List<StatedElement> StatedElements { get; set; }

        public StatedMapUpdateMessage(List<StatedElement> statedElements)
        {
            StatedElements = statedElements;
        }

        public StatedMapUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)StatedElements.Count);
            for (var statedElementsIndex = 0; statedElementsIndex < StatedElements.Count; statedElementsIndex++)
            {
                var objectToSend = StatedElements[statedElementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var statedElementsCount = reader.ReadUShort();
            StatedElements = new List<StatedElement>();
            for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
            {
                var objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                StatedElements.Add(objectToAdd);
            }
        }

    }
}
