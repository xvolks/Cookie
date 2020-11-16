using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseOnMapInformations : HouseInformations
    {
        public new const ushort ProtocolId = 510;

        public override ushort TypeID => ProtocolId;

        public List<int> DoorsOnMap { get; set; }
        public List<HouseInstanceInformations> HouseInstances { get; set; }
        public HouseOnMapInformations() { }

        public HouseOnMapInformations( List<int> DoorsOnMap, List<HouseInstanceInformations> HouseInstances ){
            this.DoorsOnMap = DoorsOnMap;
            this.HouseInstances = HouseInstances;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)DoorsOnMap.Count);
			foreach (var x in DoorsOnMap)
			{
				writer.WriteInt(x);
			}
			writer.WriteShort((short)HouseInstances.Count);
			foreach (var x in HouseInstances)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var DoorsOnMapCount = reader.ReadShort();
            DoorsOnMap = new List<int>();
            for (var i = 0; i < DoorsOnMapCount; i++)
            {
                DoorsOnMap.Add(reader.ReadInt());
            }
            var HouseInstancesCount = reader.ReadShort();
            HouseInstances = new List<HouseInstanceInformations>();
            for (var i = 0; i < HouseInstancesCount; i++)
            {
                var objectToAdd = new HouseInstanceInformations();
                objectToAdd.Deserialize(reader);
                HouseInstances.Add(objectToAdd);
            }
        }
    }
}
