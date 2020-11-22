using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InteractiveMapUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5002;

        public override ushort MessageID => ProtocolId;

        public List<InteractiveElement> InteractiveElements { get; set; }
        public InteractiveMapUpdateMessage() { }

        public InteractiveMapUpdateMessage( List<InteractiveElement> InteractiveElements ){
            this.InteractiveElements = InteractiveElements;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)InteractiveElements.Count);
			foreach (var x in InteractiveElements)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var InteractiveElementsCount = reader.ReadShort();
            InteractiveElements = new List<InteractiveElement>();
            for (var i = 0; i < InteractiveElementsCount; i++)
            {
                InteractiveElement objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                InteractiveElements.Add(objectToAdd);
            }
        }
    }
}
