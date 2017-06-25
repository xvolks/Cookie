using System.Collections.Generic;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Protocol.Network.Types.Game.Interactive;

namespace Cookie.Game.Map.Elements
{
    public class InteractiveElement : IInteractiveElement
    {
        public InteractiveElement(uint id, int typeId, List<InteractiveElementSkill> enabledSkills,
            List<InteractiveElementSkill> disabledSkills)
        {
            Id = id;
            TypeId = typeId;
            EnabledSkills = enabledSkills;
            DisabledSkills = disabledSkills;
        }

        public List<InteractiveElementSkill> DisabledSkills { get; }
        public List<InteractiveElementSkill> EnabledSkills { get; }
        public uint Id { get; }

        public bool IsUsable => EnabledSkills.Count > 0;

        public int TypeId { get; }
    }
}