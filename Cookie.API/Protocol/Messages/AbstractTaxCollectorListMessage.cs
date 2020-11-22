using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AbstractTaxCollectorListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6568;

        public override ushort MessageID => ProtocolId;

        public List<TaxCollectorInformations> Informations { get; set; }
        public AbstractTaxCollectorListMessage() { }

        public AbstractTaxCollectorListMessage( List<TaxCollectorInformations> Informations ){
            this.Informations = Informations;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Informations.Count);
			foreach (var x in Informations)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var InformationsCount = reader.ReadShort();
            Informations = new List<TaxCollectorInformations>();
            for (var i = 0; i < InformationsCount; i++)
            {
                TaxCollectorInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Informations.Add(objectToAdd);
            }
        }
    }
}
