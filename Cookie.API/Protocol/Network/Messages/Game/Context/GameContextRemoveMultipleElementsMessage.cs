using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameContextRemoveMultipleElementsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 252;

        public GameContextRemoveMultipleElementsMessage(List<double> elementsIds)
        {
            ElementsIds = elementsIds;
        }

        public GameContextRemoveMultipleElementsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<double> ElementsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) ElementsIds.Count);
            for (var elementsIdsIndex = 0; elementsIdsIndex < ElementsIds.Count; elementsIdsIndex++)
                writer.WriteDouble(ElementsIds[elementsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var elementsIdsCount = reader.ReadUShort();
            ElementsIds = new List<double>();
            for (var elementsIdsIndex = 0; elementsIdsIndex < elementsIdsCount; elementsIdsIndex++)
                ElementsIds.Add(reader.ReadDouble());
        }
    }
}