using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TaxCollectorMovementsOfflineMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6611;

        public override ushort MessageID => ProtocolId;

        public List<TaxCollectorMovement> Movements { get; set; }
        public TaxCollectorMovementsOfflineMessage() { }

        public TaxCollectorMovementsOfflineMessage( List<TaxCollectorMovement> Movements ){
            this.Movements = Movements;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Movements.Count);
			foreach (var x in Movements)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MovementsCount = reader.ReadShort();
            Movements = new List<TaxCollectorMovement>();
            for (var i = 0; i < MovementsCount; i++)
            {
                var objectToAdd = new TaxCollectorMovement();
                objectToAdd.Deserialize(reader);
                Movements.Add(objectToAdd);
            }
        }
    }
}
