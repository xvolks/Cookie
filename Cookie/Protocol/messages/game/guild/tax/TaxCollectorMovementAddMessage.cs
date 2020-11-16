using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorMovementAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5917;
        public override uint MessageID { get { return ProtocolId; } }

        public TaxCollectorInformations Informations;

        public TaxCollectorMovementAddMessage()
        {
        }

        public TaxCollectorMovementAddMessage(
            TaxCollectorInformations informations
        )
        {
            Informations = informations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Informations.TypeId);
            Informations.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var informationsTypeId = reader.ReadShort();
            Informations = new TaxCollectorInformations();
            Informations.Deserialize(reader);
        }
    }
}