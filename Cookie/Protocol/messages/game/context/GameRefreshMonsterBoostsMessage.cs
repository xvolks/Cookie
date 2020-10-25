using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRefreshMonsterBoostsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6618;
        public override uint MessageID { get { return ProtocolId; } }

        public List<MonsterBoosts> MonsterBoosts_;
        public List<MonsterBoosts> FamilyBoosts;

        public GameRefreshMonsterBoostsMessage()
        {
        }

        public GameRefreshMonsterBoostsMessage(
            List<MonsterBoosts> monsterBoosts_,
            List<MonsterBoosts> familyBoosts
        )
        {
            MonsterBoosts_ = monsterBoosts_;
            FamilyBoosts = familyBoosts;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)MonsterBoosts_.Count());
            foreach (var current in MonsterBoosts_)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)FamilyBoosts.Count());
            foreach (var current in FamilyBoosts)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMonsterBoosts_ = reader.ReadShort();
            MonsterBoosts_ = new List<MonsterBoosts>();
            for (short i = 0; i < countMonsterBoosts_; i++)
            {
                MonsterBoosts type = new MonsterBoosts();
                type.Deserialize(reader);
                MonsterBoosts_.Add(type);
            }
            var countFamilyBoosts = reader.ReadShort();
            FamilyBoosts = new List<MonsterBoosts>();
            for (short i = 0; i < countFamilyBoosts; i++)
            {
                MonsterBoosts type = new MonsterBoosts();
                type.Deserialize(reader);
                FamilyBoosts.Add(type);
            }
        }
    }
}