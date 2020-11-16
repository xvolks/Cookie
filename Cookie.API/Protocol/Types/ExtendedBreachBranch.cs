using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ExtendedBreachBranch : BreachBranch
    {
        public new const ushort ProtocolId = 560;

        public override ushort TypeID => ProtocolId;

        public List<MonsterInGroupLightInformations> Monsters { get; set; }
        public List<BreachReward> Rewards { get; set; }
        public uint Modifier { get; set; }
        public uint Prize { get; set; }
        public ExtendedBreachBranch() { }

        public ExtendedBreachBranch( List<MonsterInGroupLightInformations> Monsters, List<BreachReward> Rewards, uint Modifier, uint Prize ){
            this.Monsters = Monsters;
            this.Rewards = Rewards;
            this.Modifier = Modifier;
            this.Prize = Prize;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Monsters.Count);
			foreach (var x in Monsters)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Rewards.Count);
			foreach (var x in Rewards)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhInt(Modifier);
            writer.WriteVarUhInt(Prize);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var MonstersCount = reader.ReadShort();
            Monsters = new List<MonsterInGroupLightInformations>();
            for (var i = 0; i < MonstersCount; i++)
            {
                var objectToAdd = new MonsterInGroupLightInformations();
                objectToAdd.Deserialize(reader);
                Monsters.Add(objectToAdd);
            }
            var RewardsCount = reader.ReadShort();
            Rewards = new List<BreachReward>();
            for (var i = 0; i < RewardsCount; i++)
            {
                var objectToAdd = new BreachReward();
                objectToAdd.Deserialize(reader);
                Rewards.Add(objectToAdd);
            }
            Modifier = reader.ReadVarUhInt();
            Prize = reader.ReadVarUhInt();
        }
    }
}
