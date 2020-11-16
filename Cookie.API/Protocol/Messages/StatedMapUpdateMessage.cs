using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StatedMapUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5716;

        public override ushort MessageID => ProtocolId;

        public List<StatedElement> StatedElements { get; set; }
        public StatedMapUpdateMessage() { }

        public StatedMapUpdateMessage( List<StatedElement> StatedElements ){
            this.StatedElements = StatedElements;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)StatedElements.Count);
			foreach (var x in StatedElements)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var StatedElementsCount = reader.ReadShort();
            StatedElements = new List<StatedElement>();
            for (var i = 0; i < StatedElementsCount; i++)
            {
                var objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                StatedElements.Add(objectToAdd);
            }
        }
    }
}
