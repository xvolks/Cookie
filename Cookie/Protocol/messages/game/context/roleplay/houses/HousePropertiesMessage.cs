using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class HousePropertiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 5734;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public List<int> DoorsOnMap;
        public HouseInstanceInformations Properties;

        public HousePropertiesMessage()
        {
        }

        public HousePropertiesMessage(
            int houseId,
            List<int> doorsOnMap,
            HouseInstanceInformations properties
        )
        {
            HouseId = houseId;
            DoorsOnMap = doorsOnMap;
            Properties = properties;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteShort((short)DoorsOnMap.Count());
            foreach (var current in DoorsOnMap)
            {
                writer.WriteInt(current);
            }
            writer.WriteShort(Properties.TypeId);
            Properties.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            var countDoorsOnMap = reader.ReadShort();
            DoorsOnMap = new List<int>();
            for (short i = 0; i < countDoorsOnMap; i++)
            {
                DoorsOnMap.Add(reader.ReadInt());
            }
            var propertiesTypeId = reader.ReadShort();
            Properties = new HouseInstanceInformations();
            Properties.Deserialize(reader);
        }
    }
}