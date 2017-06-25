using System.Collections.Generic;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Protocol.Network.Types.Game.Interactive;

namespace Cookie.Game.Map.Elements
{
    public class InteractiveElement : IInteractiveElement
    {
        public InteractiveElement(uint id, int typeId, List<InteractiveElementSkill> enabledSkills, List<InteractiveElementSkill> disabledSkills)
        {
            Id = id;
            TypeId = typeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
        }

        public List<InteractiveElementSkill> DisabledSkills { get; private set; }
        public List<InteractiveElementSkill> EnabledSkills { get; private set; }
        public uint Id { get; private set; }

        public bool IsUsable
        {
            get { return EnabledSkills.Count > 0; }
        }

        public int TypeId { get; private set; }
    }
}