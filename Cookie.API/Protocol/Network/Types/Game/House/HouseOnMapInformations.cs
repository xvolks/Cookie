using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.House
{
    public class HouseOnMapInformations : HouseInformations
    {
        public new const ushort ProtocolId = 510;

        public HouseOnMapInformations(List<int> doorsOnMap, List<HouseInstanceInformations> houseInstances)
        {
            DoorsOnMap = doorsOnMap;
            HouseInstances = houseInstances;
        }

        public HouseOnMapInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<int> DoorsOnMap { get; set; }
        public List<HouseInstanceInformations> HouseInstances { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) DoorsOnMap.Count);
            for (var doorsOnMapIndex = 0; doorsOnMapIndex < DoorsOnMap.Count; doorsOnMapIndex++)
                writer.WriteInt(DoorsOnMap[doorsOnMapIndex]);
            writer.WriteShort((short) HouseInstances.Count);
            for (var houseInstancesIndex = 0; houseInstancesIndex < HouseInstances.Count; houseInstancesIndex++)
            {
                var objectToSend = HouseInstances[houseInstancesIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var doorsOnMapCount = reader.ReadUShort();
            DoorsOnMap = new List<int>();
            for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
                DoorsOnMap.Add(reader.ReadInt());
            var houseInstancesCount = reader.ReadUShort();
            HouseInstances = new List<HouseInstanceInformations>();
            for (var houseInstancesIndex = 0; houseInstancesIndex < houseInstancesCount; houseInstancesIndex++)
            {
                var objectToAdd = new HouseInstanceInformations();
                objectToAdd.Deserialize(reader);
                HouseInstances.Add(objectToAdd);
            }
        }
    }
}