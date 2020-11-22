using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HousePropertiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5734;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public List<int> DoorsOnMap { get; set; }
        public HouseInstanceInformations Properties { get; set; }
        public HousePropertiesMessage() { }

        public HousePropertiesMessage( uint HouseId, List<int> DoorsOnMap, HouseInstanceInformations Properties ){
            this.HouseId = HouseId;
            this.DoorsOnMap = DoorsOnMap;
            this.Properties = Properties;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
			writer.WriteShort((short)DoorsOnMap.Count);
			foreach (var x in DoorsOnMap)
			{
				writer.WriteInt(x);
			}
            Properties.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            var DoorsOnMapCount = reader.ReadShort();
            DoorsOnMap = new List<int>();
            for (var i = 0; i < DoorsOnMapCount; i++)
            {
                DoorsOnMap.Add(reader.ReadInt());
            }
            Properties = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Properties.Deserialize(reader);
        }
    }
}
