using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
    {
        public new const uint ProtocolId = 6416;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> ElementEventIds;

        public GameContextRemoveMultipleElementsWithEventsMessage(): base()
        {
        }

        public GameContextRemoveMultipleElementsWithEventsMessage(
            List<double> elementsIds,
            List<byte> elementEventIds
        ): base(
            elementsIds
        )
        {
            ElementEventIds = elementEventIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ElementEventIds.Count());
            foreach (var current in ElementEventIds)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countElementEventIds = reader.ReadShort();
            ElementEventIds = new List<byte>();
            for (short i = 0; i < countElementEventIds; i++)
            {
                ElementEventIds.Add(reader.ReadByte());
            }
        }
    }
}