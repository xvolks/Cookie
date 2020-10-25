using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GroupMonsterStaticInformations : NetworkType
    {
        public const short ProtocolId = 140;
        public override short TypeId { get { return ProtocolId; } }

        public MonsterInGroupLightInformations MainCreatureLightInfos;
        public List<MonsterInGroupInformations> Underlings;

        public GroupMonsterStaticInformations()
        {
        }

        public GroupMonsterStaticInformations(
            MonsterInGroupLightInformations mainCreatureLightInfos,
            List<MonsterInGroupInformations> underlings
        )
        {
            MainCreatureLightInfos = mainCreatureLightInfos;
            Underlings = underlings;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            MainCreatureLightInfos.Serialize(writer);
            writer.WriteShort((short)Underlings.Count());
            foreach (var current in Underlings)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MainCreatureLightInfos = new MonsterInGroupLightInformations();
            MainCreatureLightInfos.Deserialize(reader);
            var countUnderlings = reader.ReadShort();
            Underlings = new List<MonsterInGroupInformations>();
            for (short i = 0; i < countUnderlings; i++)
            {
                MonsterInGroupInformations type = new MonsterInGroupInformations();
                type.Deserialize(reader);
                Underlings.Add(type);
            }
        }
    }
}