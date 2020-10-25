using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class InteractiveMapUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5002;
        public override uint MessageID { get { return ProtocolId; } }

        public List<InteractiveElement> InteractiveElements;

        public InteractiveMapUpdateMessage()
        {
        }

        public InteractiveMapUpdateMessage(
            List<InteractiveElement> interactiveElements
        )
        {
            InteractiveElements = interactiveElements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)InteractiveElements.Count());
            foreach (var current in InteractiveElements)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countInteractiveElements = reader.ReadShort();
            InteractiveElements = new List<InteractiveElement>();
            for (short i = 0; i < countInteractiveElements; i++)
            {
                var interactiveElementstypeId = reader.ReadShort();
                InteractiveElement type = new InteractiveElement();
                type.Deserialize(reader);
                InteractiveElements.Add(type);
            }
        }
    }
}