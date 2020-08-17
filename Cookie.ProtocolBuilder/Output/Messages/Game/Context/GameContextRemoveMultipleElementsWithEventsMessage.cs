namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using System.Collections.Generic;
    using Utils.IO;

    public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
    {
        public new const ushort ProtocolId = 6416;
        public override ushort MessageID => ProtocolId;
        public List<byte> ElementEventIds { get; set; }

        public GameContextRemoveMultipleElementsWithEventsMessage(List<byte> elementEventIds)
        {
            ElementEventIds = elementEventIds;
        }

        public GameContextRemoveMultipleElementsWithEventsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ElementEventIds.Count);
            for (var elementEventIdsIndex = 0; elementEventIdsIndex < ElementEventIds.Count; elementEventIdsIndex++)
            {
                writer.WriteByte(ElementEventIds[elementEventIdsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var elementEventIdsCount = reader.ReadUShort();
            ElementEventIds = new List<byte>();
            for (var elementEventIdsIndex = 0; elementEventIdsIndex < elementEventIdsCount; elementEventIdsIndex++)
            {
                ElementEventIds.Add(reader.ReadByte());
            }
        }

    }
}
