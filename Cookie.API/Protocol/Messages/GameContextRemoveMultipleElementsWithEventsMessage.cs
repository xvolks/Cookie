using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
    {
        public new const ushort ProtocolId = 6416;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> ElementEventIds { get; set; }
        public GameContextRemoveMultipleElementsWithEventsMessage() { }

        public GameContextRemoveMultipleElementsWithEventsMessage( List<sbyte> ElementEventIds ){
            this.ElementEventIds = ElementEventIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)ElementEventIds.Count);
			foreach (var x in ElementEventIds)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ElementEventIdsCount = reader.ReadShort();
            ElementEventIds = new List<sbyte>();
            for (var i = 0; i < ElementEventIdsCount; i++)
            {
                ElementEventIds.Add(reader.ReadSByte());
            }
        }
    }
}
