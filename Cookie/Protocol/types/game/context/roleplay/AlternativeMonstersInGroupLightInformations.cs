using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class AlternativeMonstersInGroupLightInformations : NetworkType
    {
        public const short ProtocolId = 394;
        public override short TypeId { get { return ProtocolId; } }

        public int PlayerCount = 0;
        public List<MonsterInGroupLightInformations> Monsters;

        public AlternativeMonstersInGroupLightInformations()
        {
        }

        public AlternativeMonstersInGroupLightInformations(
            int playerCount,
            List<MonsterInGroupLightInformations> monsters
        )
        {
            PlayerCount = playerCount;
            Monsters = monsters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(PlayerCount);
            writer.WriteShort((short)Monsters.Count());
            foreach (var current in Monsters)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerCount = reader.ReadInt();
            var countMonsters = reader.ReadShort();
            Monsters = new List<MonsterInGroupLightInformations>();
            for (short i = 0; i < countMonsters; i++)
            {
                MonsterInGroupLightInformations type = new MonsterInGroupLightInformations();
                type.Deserialize(reader);
                Monsters.Add(type);
            }
        }
    }
}