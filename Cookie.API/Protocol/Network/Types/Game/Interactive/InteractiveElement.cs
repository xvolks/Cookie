using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive
{
    public class InteractiveElement : NetworkType
    {
        public const ushort ProtocolId = 80;

        public InteractiveElement(int elementId, int elementTypeId, List<InteractiveElementSkill> enabledSkills,
            List<InteractiveElementSkill> disabledSkills, bool onCurrentMap)
        {
            ElementId = elementId;
            ElementTypeId = elementTypeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
            OnCurrentMap = onCurrentMap;
        }

        public InteractiveElement()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int ElementId { get; set; }
        public int ElementTypeId { get; set; }
        public List<InteractiveElementSkill> EnabledSkills { get; set; }
        public List<InteractiveElementSkill> DisabledSkills { get; set; }
        public bool OnCurrentMap { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ElementId);
            writer.WriteInt(ElementTypeId);
            writer.WriteShort((short) EnabledSkills.Count);
            for (var enabledSkillsIndex = 0; enabledSkillsIndex < EnabledSkills.Count; enabledSkillsIndex++)
            {
                var objectToSend = EnabledSkills[enabledSkillsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) DisabledSkills.Count);
            for (var disabledSkillsIndex = 0; disabledSkillsIndex < DisabledSkills.Count; disabledSkillsIndex++)
            {
                var objectToSend = DisabledSkills[disabledSkillsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteBoolean(OnCurrentMap);
        }

        public override void Deserialize(IDataReader reader)
        {
            ElementId = reader.ReadInt();
            ElementTypeId = reader.ReadInt();
            var enabledSkillsCount = reader.ReadUShort();
            EnabledSkills = new List<InteractiveElementSkill>();
            for (var enabledSkillsIndex = 0; enabledSkillsIndex < enabledSkillsCount; enabledSkillsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                EnabledSkills.Add(objectToAdd);
            }
            var disabledSkillsCount = reader.ReadUShort();
            DisabledSkills = new List<InteractiveElementSkill>();
            for (var disabledSkillsIndex = 0; disabledSkillsIndex < disabledSkillsCount; disabledSkillsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                DisabledSkills.Add(objectToAdd);
            }
            OnCurrentMap = reader.ReadBoolean();
        }
    }
}