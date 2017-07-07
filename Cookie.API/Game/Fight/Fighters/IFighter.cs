using Cookie.API.Game.Entity;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;

namespace Cookie.API.Game.Fight.Fighters
{
    public interface IFighter : IEntity
    {
        /// <summary>
        ///     Points de vie actuel de l'entité
        /// </summary>
        uint LifePoints { get; }

        /// <summary>
        ///     Points de vie maximum de l'entité
        /// </summary>
        uint MaxLifePoints { get; }

        /// <summary>
        ///     PA de l'entité
        /// </summary>
        short ActionPoints { get; }

        /// <summary>
        ///     MP de l'entité
        /// </summary>
        short MovementPoints { get; }

        /// <summary>
        ///     Indique si l'entité est vivante
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        ///     Equipe de l'entité
        /// </summary>
        uint TeamId { get; }

        /// <summary>
        ///     Stats minimals du combat de l'entité
        /// </summary>
        GameFightMinimalStats Stats { get; }
    }
}