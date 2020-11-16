using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class InteractiveElementWithAgeBonus : InteractiveElement
    {
        public new const short ProtocolId = 398;
        public override short TypeId { get { return ProtocolId; } }

        public short AgeBonus = 0;

        public InteractiveElementWithAgeBonus(): base()
        {
        }

        public InteractiveElementWithAgeBonus(
            int elementId,
            int elementTypeId,
            List<InteractiveElementSkill> enabledSkills,
            List<InteractiveElementSkill> disabledSkills,
            bool onCurrentMap,
            short ageBonus
        ): base(
            elementId,
            elementTypeId,
            enabledSkills,
            disabledSkills,
            onCurrentMap
        )
        {
            AgeBonus = ageBonus;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(AgeBonus);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AgeBonus = reader.ReadShort();
        }
    }
}