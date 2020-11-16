using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AnomalySubareaInformationResponseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6836;
        public override uint MessageID { get { return ProtocolId; } }

        public List<AnomalySubareaInformation> Subareas;

        public AnomalySubareaInformationResponseMessage()
        {
        }

        public AnomalySubareaInformationResponseMessage(
            List<AnomalySubareaInformation> subareas
        )
        {
            Subareas = subareas;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Subareas.Count());
            foreach (var current in Subareas)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countSubareas = reader.ReadShort();
            Subareas = new List<AnomalySubareaInformation>();
            for (short i = 0; i < countSubareas; i++)
            {
                AnomalySubareaInformation type = new AnomalySubareaInformation();
                type.Deserialize(reader);
                Subareas.Add(type);
            }
        }
    }
}