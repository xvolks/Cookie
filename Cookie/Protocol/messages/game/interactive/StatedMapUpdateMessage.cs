using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class StatedMapUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5716;
        public override uint MessageID { get { return ProtocolId; } }

        public List<StatedElement> StatedElements;

        public StatedMapUpdateMessage()
        {
        }

        public StatedMapUpdateMessage(
            List<StatedElement> statedElements
        )
        {
            StatedElements = statedElements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)StatedElements.Count());
            foreach (var current in StatedElements)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countStatedElements = reader.ReadShort();
            StatedElements = new List<StatedElement>();
            for (short i = 0; i < countStatedElements; i++)
            {
                StatedElement type = new StatedElement();
                type.Deserialize(reader);
                StatedElements.Add(type);
            }
        }
    }
}