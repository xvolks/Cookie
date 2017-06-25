using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie.API.Game.Entity
{
    public interface IEntity
    {
        /// <summary>Cellule de l'entité</summary>
        int CellId { get; }
        /// <summary>Identifiant de l'entité</summary>
        int Id { get; }
    }
}
