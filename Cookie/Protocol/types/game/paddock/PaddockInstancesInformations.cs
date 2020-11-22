using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockInstancesInformations : PaddockInformations
    {
        public new const short ProtocolId = 509;
        public override short TypeId { get { return ProtocolId; } }

        public List<PaddockBuyableInformations> Paddocks;

        public PaddockInstancesInformations(): base()
        {
        }

        public PaddockInstancesInformations(
            short maxOutdoorMount,
            short maxItems,
            List<PaddockBuyableInformations> paddocks
        ): base(
            maxOutdoorMount,
            maxItems
        )
        {
            Paddocks = paddocks;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Paddocks.Count());
            foreach (var current in Paddocks)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countPaddocks = reader.ReadShort();
            Paddocks = new List<PaddockBuyableInformations>();
            for (short i = 0; i < countPaddocks; i++)
            {
                var paddockstypeId = reader.ReadShort();
                PaddockBuyableInformations type = new PaddockBuyableInformations();
                type.Deserialize(reader);
                Paddocks.Add(type);
            }
        }
    }
}