using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameRefreshMonsterBoostsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6618;

        public GameRefreshMonsterBoostsMessage(List<MonsterBoosts> monsterBoosts, List<MonsterBoosts> familyBoosts)
        {
            MonsterBoosts = monsterBoosts;
            FamilyBoosts = familyBoosts;
        }

        public GameRefreshMonsterBoostsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<MonsterBoosts> MonsterBoosts { get; set; }
        public List<MonsterBoosts> FamilyBoosts { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MonsterBoosts.Count);
            for (var monsterBoostsIndex = 0; monsterBoostsIndex < MonsterBoosts.Count; monsterBoostsIndex++)
            {
                var objectToSend = MonsterBoosts[monsterBoostsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) FamilyBoosts.Count);
            for (var familyBoostsIndex = 0; familyBoostsIndex < FamilyBoosts.Count; familyBoostsIndex++)
            {
                var objectToSend = FamilyBoosts[familyBoostsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var monsterBoostsCount = reader.ReadUShort();
            MonsterBoosts = new List<MonsterBoosts>();
            for (var monsterBoostsIndex = 0; monsterBoostsIndex < monsterBoostsCount; monsterBoostsIndex++)
            {
                var objectToAdd = new MonsterBoosts();
                objectToAdd.Deserialize(reader);
                MonsterBoosts.Add(objectToAdd);
            }
            var familyBoostsCount = reader.ReadUShort();
            FamilyBoosts = new List<MonsterBoosts>();
            for (var familyBoostsIndex = 0; familyBoostsIndex < familyBoostsCount; familyBoostsIndex++)
            {
                var objectToAdd = new MonsterBoosts();
                objectToAdd.Deserialize(reader);
                FamilyBoosts.Add(objectToAdd);
            }
        }
    }
}