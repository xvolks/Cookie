using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class ExtendedBreachBranch : BreachBranch
    {
        public new const short ProtocolId = 560;
        public override short TypeId { get { return ProtocolId; } }

        public List<MonsterInGroupLightInformations> Monsters;
        public List<BreachReward> Rewards;
        public int Modifier = 0;
        public int Prize = 0;

        public ExtendedBreachBranch(): base()
        {
        }

        public ExtendedBreachBranch(
            byte room,
            int element,
            List<MonsterInGroupLightInformations> bosses,
            double map,
            List<MonsterInGroupLightInformations> monsters,
            List<BreachReward> rewards,
            int modifier,
            int prize
        ): base(
            room,
            element,
            bosses,
            map
        )
        {
            Monsters = monsters;
            Rewards = rewards;
            Modifier = modifier;
            Prize = prize;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Monsters.Count());
            foreach (var current in Monsters)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)Rewards.Count());
            foreach (var current in Rewards)
            {
                current.Serialize(writer);
            }
            writer.WriteVarInt(Modifier);
            writer.WriteVarInt(Prize);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countMonsters = reader.ReadShort();
            Monsters = new List<MonsterInGroupLightInformations>();
            for (short i = 0; i < countMonsters; i++)
            {
                MonsterInGroupLightInformations type = new MonsterInGroupLightInformations();
                type.Deserialize(reader);
                Monsters.Add(type);
            }
            var countRewards = reader.ReadShort();
            Rewards = new List<BreachReward>();
            for (short i = 0; i < countRewards; i++)
            {
                BreachReward type = new BreachReward();
                type.Deserialize(reader);
                Rewards.Add(type);
            }
            Modifier = reader.ReadVarInt();
            Prize = reader.ReadVarInt();
        }
    }
}