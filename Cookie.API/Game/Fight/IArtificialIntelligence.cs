using Cookie.API.Core;
using Cookie.API.Datacenter;
using System.Collections.Generic;

namespace Cookie.API.Game.Fight
{
    public interface IArtificialIntelligence
    {
        /// <summary>
        ///     Charge l'IA
        /// </summary>
        void Load(IAccount account, string path);
    }
}