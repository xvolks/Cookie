using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class BreachBranch : NetworkType
    {
        public const short ProtocolId = 558;
        public override short TypeId { get { return ProtocolId; } }

        public byte Room = 0;
        public int Element = 0;
        public List<MonsterInGroupLightInformations> Bosses;
        public double Map = 0;

        public BreachBranch()
        {
        }

        public BreachBranch(
            byte room,
            int element,
            List<MonsterInGroupLightInformations> bosses,
            double map
        )
        {
            Room = room;
            Element = element;
            Bosses = bosses;
            Map = map;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Room);
            writer.WriteInt(Element);
            writer.WriteShort((short)Bosses.Count());
            foreach (var current in Bosses)
            {
                current.Serialize(writer);
            }
            writer.WriteDouble(Map);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Room = reader.ReadByte();
            Element = reader.ReadInt();
            var countBosses = reader.ReadShort();
            Bosses = new List<MonsterInGroupLightInformations>();
            for (short i = 0; i < countBosses; i++)
            {
                MonsterInGroupLightInformations type = new MonsterInGroupLightInformations();
                type.Deserialize(reader);
                Bosses.Add(type);
            }
            Map = reader.ReadDouble();
        }
    }
}