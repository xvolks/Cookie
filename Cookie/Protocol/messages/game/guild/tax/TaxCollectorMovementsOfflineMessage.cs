using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorMovementsOfflineMessage : NetworkMessage
    {
        public const uint ProtocolId = 6611;
        public override uint MessageID { get { return ProtocolId; } }

        public List<TaxCollectorMovement> Movements;

        public TaxCollectorMovementsOfflineMessage()
        {
        }

        public TaxCollectorMovementsOfflineMessage(
            List<TaxCollectorMovement> movements
        )
        {
            Movements = movements;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Movements.Count());
            foreach (var current in Movements)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMovements = reader.ReadShort();
            Movements = new List<TaxCollectorMovement>();
            for (short i = 0; i < countMovements; i++)
            {
                TaxCollectorMovement type = new TaxCollectorMovement();
                type.Deserialize(reader);
                Movements.Add(type);
            }
        }
    }
}