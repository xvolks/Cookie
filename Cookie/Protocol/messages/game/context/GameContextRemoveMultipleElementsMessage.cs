using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextRemoveMultipleElementsMessage : NetworkMessage
    {
        public const uint ProtocolId = 252;
        public override uint MessageID { get { return ProtocolId; } }

        public List<double> ElementsIds;

        public GameContextRemoveMultipleElementsMessage()
        {
        }

        public GameContextRemoveMultipleElementsMessage(
            List<double> elementsIds
        )
        {
            ElementsIds = elementsIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)ElementsIds.Count());
            foreach (var current in ElementsIds)
            {
                writer.WriteDouble(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countElementsIds = reader.ReadShort();
            ElementsIds = new List<double>();
            for (short i = 0; i < countElementsIds; i++)
            {
                ElementsIds.Add(reader.ReadDouble());
            }
        }
    }
}