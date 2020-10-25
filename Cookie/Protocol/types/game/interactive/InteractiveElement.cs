using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class InteractiveElement : NetworkType
    {
        public const short ProtocolId = 80;
        public override short TypeId { get { return ProtocolId; } }

        public int ElementId = 0;
        public int ElementTypeId = 0;
        public List<InteractiveElementSkill> EnabledSkills;
        public List<InteractiveElementSkill> DisabledSkills;
        public bool OnCurrentMap = false;

        public InteractiveElement()
        {
        }

        public InteractiveElement(
            int elementId,
            int elementTypeId,
            List<InteractiveElementSkill> enabledSkills,
            List<InteractiveElementSkill> disabledSkills,
            bool onCurrentMap
        )
        {
            ElementId = elementId;
            ElementTypeId = elementTypeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
            OnCurrentMap = onCurrentMap;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteInt(ElementTypeId);
            writer.WriteShort((short)EnabledSkills.Count());
            foreach (var current in EnabledSkills)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)DisabledSkills.Count());
            foreach (var current in DisabledSkills)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteBoolean(OnCurrentMap);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ElementId = reader.ReadInt();
            ElementTypeId = reader.ReadInt();
            var countEnabledSkills = reader.ReadShort();
            EnabledSkills = new List<InteractiveElementSkill>();
            for (short i = 0; i < countEnabledSkills; i++)
            {
                var enabledSkillstypeId = reader.ReadShort();
                InteractiveElementSkill type = new InteractiveElementSkill();
                type.Deserialize(reader);
                EnabledSkills.Add(type);
            }
            var countDisabledSkills = reader.ReadShort();
            DisabledSkills = new List<InteractiveElementSkill>();
            for (short i = 0; i < countDisabledSkills; i++)
            {
                var disabledSkillstypeId = reader.ReadShort();
                InteractiveElementSkill type = new InteractiveElementSkill();
                type.Deserialize(reader);
                DisabledSkills.Add(type);
            }
            OnCurrentMap = reader.ReadBoolean();
        }
    }
}