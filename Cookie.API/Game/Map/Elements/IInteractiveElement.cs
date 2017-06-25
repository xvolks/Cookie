using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Interactive;

namespace Cookie.API.Game.Map.Elements
{
    public interface IInteractiveElement
    {
        List<InteractiveElementSkill> DisabledSkills { get; }
        List<InteractiveElementSkill> EnabledSkills { get; }

        /// <summary>Identifiant de cet élément</summary>
        uint Id { get; }

        /// <summary>Indique si la liste des compétences utilisables n'est pas vide</summary>
        /// <returns>True si la liste des compétences utilisables n'est pas vide, sinon false</returns>
        bool IsUsable { get; }

        int TypeId { get; }
    }
}