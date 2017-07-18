using System;
using System.Collections.Generic;
using Cookie.API.Game.Entity;
using Cookie.API.Game.Map.Elements;
using Cookie.API.Protocol.Network.Messages.Game.Context;

namespace Cookie.API.Game.Map
{
    public interface IMap
    {
        List<IEntity> Entities { get; }
        List<IMonsterGroup> Monsters { get; }
        List<INpc> Npcs { get; }
        List<IPlayer> Players { get; }
        List<IMerchant> Merchants { get; }

        /// <summary>Récupère le dictionnaire des portes de la carte</summary>
        /// <returns>Dictionnaire (cellId, element) contenant les portes</returns>
        Dictionary<int, IInteractiveElement> Doors { get; }

        /// <summary>Retourne le dictionnaire des éléments utilisable sur la map</summary>
        /// <returns>Dictionnaire (id, element) de IUsableElement</returns>
        Dictionary<int, IUsableElement> UsableElements { get; }

        /// <summary>Retourne le dictionnaire des éléments à état sur la map</summary>
        /// <returns>Dictionnaire (id, element) de IStatedElement</returns>
        Dictionary<int, IStatedElement> StatedElements { get; }

        /// <summary>Récupère l'identifiant du monde actuel</summary>
        /// <returns>L'id du monde</returns>
        int WorldId { get; }

        // Properties
        /// <summary>Récupère le personnage actuellement joué</summary>
        IEntity Character { get; }

        /// <summary>Contient des informations fixes sur la carte</summary>
        IMapData Data { get; }

        /// <summary>Identifiant de la carte</summary>
        int Id { get; }

        /// <summary>Position en X de la carte</summary>
        int X { get; }

        /// <summary>Position en Y de la carte</summary>
        int Y { get; }

        /// <summary>Contient les éléments interactifs présents sur la carte (id, element)</summary>
        Dictionary<int, IInteractiveElement> InteractiveElements { get; }

        /// <summary>Identifiant de la zone actuelle</summary>
        int SubAreaId { get; }

        /// <summary>
        ///     Si différent de -1, indique le changement de carte à effectuer à la fin du déplacement. Si égal à -2, détecte
        ///     automatiquement le changement de carte à réaliser
        /// </summary>
        int MapChange { get; set; }

        // Methods
        /// <summary>Indique si l'élément indiqué peut-être récolté depuis la position actuelle du personnage</summary>
        /// <param name="id">Identifiant de l'élément interactif à récolter</param>
        /// <param name="distance">Distance entre l'élément interactif et le personnage</param>
        /// <returns>True si l'élément peut être récolté, sinon false</returns>
        bool CanGatherElement(int id, int distance);

        /// <summary>Change de carte vers la direction indiquée, en utilisant MoveToCell et MapChange</summary>
        /// <param name="direction">Direction dans laquelle changer de carte</param>
        /// <returns>True si le personnage se déplace ou change de carte, sinon false</returns>
        IMapChangement ChangeMap(MapDirectionEnum direction);

        /// <summary>Se déplace sur la cellule indiquée</summary>
        /// <param name="cellId">Cellule sur laquelle se déplacer</param>
        /// <returns>True si le personnage se déplace, sinon false</returns>
        //bool MoveToCell(int cellId);
        /// <summary>Se déplace en vue d'utiliser un élément interactif de type porte</summary>
        /// <param name="cellId">Case de la porte</param>
        /// <returns>True si le personnage se déplace, sinon false</returns>
        ICellMovement MoveToDoor(int cellId);

        /// <summary>Se déplace en vue d'utiliser un élément interactif</summary>
        /// <param name="id">Identifiant de l'élément interactif à récolter</param>
        /// <param name="maxDistance">Distance maximum à laquelle se placer de l'élement</param>
        /// <returns>True si le personnage se déplace, sinon false</returns>
        ICellMovement MoveToElement(int id, int maxDistance);

        /// <summary>Se déplace sur un element</summary>
        /// <param name="id">Identifiant de l'élément</param>
        /// <returns>True si le personnage se déplace, sinon false</returns>
        ICellMovement MoveToSecureElement(int id);

        /// <summary>Indique si aucune entité ne se trouve sur la cellule</summary>
        /// <param name="cellId">Identificateur de la cellule</param>
        /// <returns>True si il n'y a aucune entité, sinon false</returns>
        bool NoEntitiesOnCell(int cellId);

        /// <summary>Indique si la cellule est marchable et si aucune entité ne s'y trouve</summary>
        /// <param name="cellId">Identificateur de la cellule</param>
        /// <returns>True si il n'y a rien, sinon false</returns>
        bool NothingOnCell(int cellId);

        /// <summary>Utilise (ou récolte) l'élement indiqué avec la compétence indiquée</summary>
        /// <param name="id">Identifiant de l'élément interactif à récolter</param>
        /// <param name="skillId">Identifiant unique de la compétence à utiliser</param>
        void UseElement(int id, int skillId);

        void LaunchAttack();

        void LaunchAttackByCellId(ushort cellId);

        void LaunchAttackByMonsterGroup(IMonsterGroup monsterGroup);

        ICellMovement MoveToCellWithDistance(int cellId, int maxDistance, bool bool1);

        event EventHandler MovementConfirmed;

        event EventHandler MovementFailed;

        event Action<GameMapMovementMessage> MapMovement;

        event EventHandler<MapChangedEventArgs> MapChanged;

        ICellMovement MoveToCell(int cellId);

        void PlayerFightRequest(string playerName);
    }
}