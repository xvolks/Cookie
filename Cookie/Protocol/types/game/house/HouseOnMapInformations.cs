using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class HouseOnMapInformations : HouseInformations
    {
        public new const short ProtocolId = 510;
        public override short TypeId { get { return ProtocolId; } }

        public List<int> DoorsOnMap;
        public List<HouseInstanceInformations> HouseInstances;

        public HouseOnMapInformations(): base()
        {
        }

        public HouseOnMapInformations(
            int houseId,
            short modelId,
            List<int> doorsOnMap,
            List<HouseInstanceInformations> houseInstances
        ): base(
            houseId,
            modelId
        )
        {
            DoorsOnMap = doorsOnMap;
            HouseInstances = houseInstances;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)DoorsOnMap.Count());
            foreach (var current in DoorsOnMap)
            {
                writer.WriteInt(current);
            }
            writer.WriteShort((short)HouseInstances.Count());
            foreach (var current in HouseInstances)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countDoorsOnMap = reader.ReadShort();
            DoorsOnMap = new List<int>();
            for (short i = 0; i < countDoorsOnMap; i++)
            {
                DoorsOnMap.Add(reader.ReadInt());
            }
            var countHouseInstances = reader.ReadShort();
            HouseInstances = new List<HouseInstanceInformations>();
            for (short i = 0; i < countHouseInstances; i++)
            {
                HouseInstanceInformations type = new HouseInstanceInformations();
                type.Deserialize(reader);
                HouseInstances.Add(type);
            }
        }
    }
}