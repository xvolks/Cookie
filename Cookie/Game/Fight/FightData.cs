using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Game.Fight;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Actions.Fight;
using Cookie.API.Protocol.Network.Messages.Game.Character.Stats;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Character;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Game.Fight.Fighters;

namespace Cookie.Game.Fight
{
    public class FightData : IFightData
    {
        public FightData(IAccount account)
        {
            Account = account;
            IsFightStarted = false;
            Fighters = new List<IFighter>();

            Account.Network.RegisterPacket<GameFightShowFighterMessage>(HandleGameFightShowFighterMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightShowFighterRandomStaticPoseMessage>(
                HandleGameFightShowFighterRandomStaticPoseMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<FighterStatsListMessage>(HandleFighterStatsListMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameActionFightDeathMessage>(HandleGameActionFightDeathMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightEndMessage>(HandleGameFightEndMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightStartMessage>(HandleGameFightStartMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightLeaveMessage>(HandleGameFightLeaveMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightHumanReadyStateMessage>(HandleGameFightHumanReadyStateMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameEntitiesDispositionMessage>(HandleGameEntitiesDispositionMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightSynchronizeMessage>(HandleGameFightSynchronizeMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightTurnStartMessage>(HandleGameFightTurnStartMessage,
                MessagePriority.VeryHigh);
        }

        public bool IsFightStarted { get; protected set; }
        public bool IsFighterTurn { get; protected set; }
        public bool WaitForReady { get; protected set; }
        protected object CheckLock { get; set; }
        protected IAccount Account { get; set; }

        public IFighter Fighter => GetFighter((int) Account.Character.Id);

        public List<IFighter> Fighters { get; protected set; }
        public int TurnId { get; protected set; }

        #region Event

        public event Action<object, GameFightEndMessage> FightEnded;
        public event Action<object, List<IFighter>> FightStarted;
        public event Action<object> TurnStarted;

        #endregion

        #region Handle

        private void HandleGameFightShowFighterMessage(IAccount account, GameFightShowFighterMessage message)
        {
            lock (CheckLock)
            {
                Fighters.Add(new Fighter((int) message.Informations.ContextualId,
                    message.Informations.Disposition.CellId, message.Informations.Stats, message.Informations.TeamId,
                    message.Informations.Alive));
            }
        }

        private void HandleGameEntitiesDispositionMessage(IAccount account, GameEntitiesDispositionMessage message)
        {
            message.Dispositions.ToList().ForEach(d =>
            {
                var fighter = GetFighter((int) d.ObjectId);
                if (fighter != null)
                    ((Fighter) fighter).CellId = d.CellId;
            });
            Account.Character.Status = CharacterStatus.Fighting;
        }

        private void HandleGameFightTurnStartMessage(IAccount account, GameFightTurnStartMessage message)
        {
            if (!IsFightStarted)
                IsFightStarted = true;

            if (message.ObjectId == Account.Character.Id)
            {
                IsFighterTurn = true;
                Account.Character.Status = CharacterStatus.Fighting;
                TurnStarted?.Invoke(this);
            }
            else
            {
                IsFighterTurn = false;
            }
            TurnId = (int) message.ObjectId;
        }

        private void HandleGameFightShowFighterRandomStaticPoseMessage(IAccount account,
            GameFightShowFighterRandomStaticPoseMessage message)
        {
            HandleGameFightShowFighterMessage(account, message);
        }

        private void HandleGameFightHumanReadyStateMessage(IAccount account, GameFightHumanReadyStateMessage message)
        {
            if (message.CharacterId == Account.Character.Id)
                WaitForReady = !message.IsReady;
        }

        private void HandleGameFightSynchronizeMessage(IAccount account, GameFightSynchronizeMessage message)
        {
            lock (CheckLock)
            {
                Fighters.Clear();
                Fighters.AddRange(
                    message.Fighters.Select(f => new Fighter((int) f.ContextualId, f.Disposition.CellId, f.Stats,
                        f.TeamId, f.Alive)));
            }
            Account.Character.Status = CharacterStatus.Fighting;
        }

        private void HandleGameFightLeaveMessage(IAccount account, GameFightLeaveMessage message)
        {
            if (message.CharId == Account.Character.Id)
            {
                IsFightStarted = false;
                WaitForReady = false;
            }
            else
            {
                lock (CheckLock)
                {
                    var fighter = GetFighter((int) message.CharId);
                    if (fighter != null)
                        Fighters.Remove(fighter);
                }
            }
        }

        private void HandleGameFightStartMessage(IAccount account, GameFightStartMessage message)
        {
            WaitForReady = false;
            IsFightStarted = true;
            FightStarted?.Invoke(this, Fighters);
            Account.Character.Status = CharacterStatus.Fighting;
            Logger.Default.Log("Début du combat");
        }

        private void HandleGameFightEndMessage(IAccount account, GameFightEndMessage message)
        {
            WaitForReady = false;
            IsFighterTurn = false;
            IsFightStarted = false;
            FightEnded?.Invoke(this, message);

            Account.Character.Status = CharacterStatus.None;
        }

        private void HandleFighterStatsListMessage(IAccount account, FighterStatsListMessage message)
        {
            Account.Character.Stats = message.Stats;
        }

        private void HandleGameActionFightDeathMessage(IAccount account, GameActionFightDeathMessage message)
        {
            var fighter = (Fighter) GetFighter((int) message.TargetId);
            if (fighter.TeamId == 1)
            {
                var monster = (Monster) fighter;
                Logger.Default.Log($"{monster.Name} mort");
            }
            else
            {
                Logger.Default.Log("Combattant mort");
            }
            Fighters.Remove(fighter);
        }

        #endregion

        #region Public Fonction

        public IMonster NearestMonster()
        {
            var savDistance = -1;
            foreach (var fighter in Fighters)
            {
                var monster = (Monster) fighter;
                if (monster.TeamId == Fighter.TeamId || monster.IsAlive == false)
                    continue;
                var dist = DistanceFrom(monster);
                if ((dist >= savDistance && savDistance != -1) || monster == Fighter) continue;
                savDistance = dist;
                return monster;
            }
            return null;
        }

        public bool IsHandToHand()
        {
            var characterPoint = new MapPoint(Fighter.CellId);
            var targetPoint = new MapPoint(NearestMonster().CellId);

            if (characterPoint.DistanceToCell(targetPoint) <= 1)
                return true;

            return false;
        }

        public List<int> GetReachableCells()
        {
            var listWalkableCells = new List<int>();
            var point = new MapPoint(Fighter.CellId);
            int movementPoints = Fighter.MovementPoints;

            for (var i = 0; i < 600; i++)
                if (IsCellWalkable(i))
                {
                    var cellPoint = new MapPoint(i);
                    if (cellPoint.DistanceToCell(point) <= movementPoints)
                        listWalkableCells.Add(i);
                }

            if (listWalkableCells.Contains(point.CellId))
                listWalkableCells.Add(point.CellId);

            return listWalkableCells;
        }

        #endregion

        #region Protected Fonction

        protected int DistanceFrom(Fighter fighter)
        {
            var characterPoint = new MapPoint(Fighter.CellId);
            var testFighterPoint = new MapPoint(fighter.CellId);
            var dist = new SimplePathfinder((API.Gamedata.D2p.Map) Account.Character.Map.Data)
                .FindPath(fighter.CellId, testFighterPoint.CellId).Cells.Count();
            dist += characterPoint.DistanceToCell(testFighterPoint);
            return dist;
        }

        protected IFighter GetFighter(int fighterId)
        {
            return Fighters.FirstOrDefault(f => f.Id == fighterId);
        }

        protected bool IsFreeCell(int cellId)
        {
            return !Fighters.Any(f => f != null && f.CellId == cellId);
        }

        protected bool IsCellWalkable(int cellId)
        {
            lock (CheckLock)
            {
                var MapData = (API.Gamedata.D2p.Map) Account.Character.Map.Data;
                if (Account.Character.Map.Data.IsWalkable(cellId))
                {
                    var selectedFighter =
                        Fighters.FirstOrDefault(f => f.CellId == cellId ||
                                                     MapData.Cells[cellId].NonWalkableDuringFight);
                    if (selectedFighter != null)
                        return false;
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}