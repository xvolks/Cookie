using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Guild.Tax;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class AbstractTaxCollectorListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6568;

        public AbstractTaxCollectorListMessage(List<TaxCollectorInformations> informations)
        {
            Informations = informations;
        }

        public AbstractTaxCollectorListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<TaxCollectorInformations> Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Informations.Count);
            for (var informationsIndex = 0; informationsIndex < Informations.Count; informationsIndex++)
            {
                var objectToSend = Informations[informationsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var informationsCount = reader.ReadUShort();
            Informations = new List<TaxCollectorInformations>();
            for (var informationsIndex = 0; informationsIndex < informationsCount; informationsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Informations.Add(objectToAdd);
            }
        }
    }
}