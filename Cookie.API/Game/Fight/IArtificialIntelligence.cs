using Cookie.API.Core;

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