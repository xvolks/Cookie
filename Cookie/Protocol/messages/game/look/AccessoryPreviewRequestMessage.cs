using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AccessoryPreviewRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6518;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> GenericId;

        public AccessoryPreviewRequestMessage()
        {
        }

        public AccessoryPreviewRequestMessage(
            List<short> genericId
        )
        {
            GenericId = genericId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)GenericId.Count());
            foreach (var current in GenericId)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countGenericId = reader.ReadShort();
            GenericId = new List<short>();
            for (short i = 0; i < countGenericId; i++)
            {
                GenericId.Add(reader.ReadVarShort());
            }
        }
    }
}