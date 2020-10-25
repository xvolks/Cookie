using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractTaxCollectorListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6568;
        public override uint MessageID { get { return ProtocolId; } }

        public List<TaxCollectorInformations> Informations;

        public AbstractTaxCollectorListMessage()
        {
        }

        public AbstractTaxCollectorListMessage(
            List<TaxCollectorInformations> informations
        )
        {
            Informations = informations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Informations.Count());
            foreach (var current in Informations)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countInformations = reader.ReadShort();
            Informations = new List<TaxCollectorInformations>();
            for (short i = 0; i < countInformations; i++)
            {
                var informationstypeId = reader.ReadShort();
                TaxCollectorInformations type = new TaxCollectorInformations();
                type.Deserialize(reader);
                Informations.Add(type);
            }
        }
    }
}