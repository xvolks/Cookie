using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Interactive;

namespace Cookie.API.Game.Map.Elements
{
    public interface IUsableElement
    {
        /// <summary>Id des actions disponibles</summary>
        List<InteractiveElementSkill> Skills { get; }

        /// <summary>Cellule de l'élément</summary>
        int CellId { get; }

        /// <summary>Élément</summary>
        IInteractiveElement Element { get; }
    }
}