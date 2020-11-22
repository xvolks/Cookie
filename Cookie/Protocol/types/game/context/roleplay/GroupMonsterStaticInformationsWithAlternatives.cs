using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
    {
        public new const short ProtocolId = 396;
        public override short TypeId { get { return ProtocolId; } }

        public List<AlternativeMonstersInGroupLightInformations> Alternatives;

        public GroupMonsterStaticInformationsWithAlternatives(): base()
        {
        }

        public GroupMonsterStaticInformationsWithAlternatives(
            MonsterInGroupLightInformations mainCreatureLightInfos,
            List<MonsterInGroupInformations> underlings,
            List<AlternativeMonstersInGroupLightInformations> alternatives
        ): base(
            mainCreatureLightInfos,
            underlings
        )
        {
            Alternatives = alternatives;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Alternatives.Count());
            foreach (var current in Alternatives)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countAlternatives = reader.ReadShort();
            Alternatives = new List<AlternativeMonstersInGroupLightInformations>();
            for (short i = 0; i < countAlternatives; i++)
            {
                AlternativeMonstersInGroupLightInformations type = new AlternativeMonstersInGroupLightInformations();
                type.Deserialize(reader);
                Alternatives.Add(type);
            }
        }
    }
}