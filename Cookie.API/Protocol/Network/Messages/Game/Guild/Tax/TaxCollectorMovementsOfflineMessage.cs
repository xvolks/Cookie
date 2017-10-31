namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Types.Game.Guild.Tax;
    using System.Collections.Generic;
    using Utils.IO;

    public class TaxCollectorMovementsOfflineMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6611;
        public override ushort MessageID => ProtocolId;
        public List<TaxCollectorMovement> Movements { get; set; }

        public TaxCollectorMovementsOfflineMessage(List<TaxCollectorMovement> movements)
        {
            Movements = movements;
        }

        public TaxCollectorMovementsOfflineMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Movements.Count);
            for (var movementsIndex = 0; movementsIndex < Movements.Count; movementsIndex++)
            {
                var objectToSend = Movements[movementsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var movementsCount = reader.ReadUShort();
            Movements = new List<TaxCollectorMovement>();
            for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
            {
                var objectToAdd = new TaxCollectorMovement();
                objectToAdd.Deserialize(reader);
                Movements.Add(objectToAdd);
            }
        }

    }
}
