using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextRemoveMultipleElementsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 252;

        public override ushort MessageID => ProtocolId;

        public List<double> ElementsIds { get; set; }
        public GameContextRemoveMultipleElementsMessage() { }

        public GameContextRemoveMultipleElementsMessage( List<double> ElementsIds ){
            this.ElementsIds = ElementsIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)ElementsIds.Count);
			foreach (var x in ElementsIds)
			{
				writer.WriteDouble(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ElementsIdsCount = reader.ReadShort();
            ElementsIds = new List<double>();
            for (var i = 0; i < ElementsIdsCount; i++)
            {
                ElementsIds.Add(reader.ReadDouble());
            }
        }
    }
}
