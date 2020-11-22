using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class BreachBranch : NetworkType
    {
        public const ushort ProtocolId = 558;

        public override ushort TypeID => ProtocolId;

        public sbyte Room { get; set; }
        public int Element { get; set; }
        public List<MonsterInGroupLightInformations> Bosses { get; set; }
        public double Map { get; set; }
        public BreachBranch() { }

        public BreachBranch( sbyte Room, int Element, List<MonsterInGroupLightInformations> Bosses, double Map ){
            this.Room = Room;
            this.Element = Element;
            this.Bosses = Bosses;
            this.Map = Map;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Room);
            writer.WriteInt(Element);
			writer.WriteShort((short)Bosses.Count);
			foreach (var x in Bosses)
			{
				x.Serialize(writer);
			}
            writer.WriteDouble(Map);
        }

        public override void Deserialize(IDataReader reader)
        {
            Room = reader.ReadSByte();
            Element = reader.ReadInt();
            var BossesCount = reader.ReadShort();
            Bosses = new List<MonsterInGroupLightInformations>();
            for (var i = 0; i < BossesCount; i++)
            {
                var objectToAdd = new MonsterInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Bosses.Add(objectToAdd);
            }
            Map = reader.ReadDouble();
        }
    }
}
