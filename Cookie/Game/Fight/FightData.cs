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
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;

namespace Cookie.Game.Fight
{
    public class FightData : IFightData
    {
        public FightData(IAccount account)
        {
            Account = account;
            IsFightStarted = false;
            Fighters = new List<IFighter>();
            Monsters = new List<IMonster>();
            Companions = new List<ICompanion>();

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

        public IFighter Fighter => GetFighter(Account.Character.Id);

        public List<IFighter> Fighters { get; protected set; }
        public List<IMonster> Monsters { get; protected set; }
        public List<ICompanion> Companions { get; protected set; }
        public int TurnId { get; protected set; }

        #region Event

        public event Action<object, GameFightEndMessage> FightEnded;
        public event Action<object> FightStarted;
        public event Action<object> TurnStarted;

        #endregion

        #region Handle

        private void HandleGameFightShowFighterMessage(IAccount account, GameFightShowFighterMessage message)
        {
            lock (CheckLock)
            {
                AddFighter(message.Informations);
            }
        }

        private void HandleGameEntitiesDispositionMessage(IAccount account, GameEntitiesDispositionMessage message)
        {
            message.Dispositions.ToList().ForEach(d =>
            {
                if (Fighters.Find(x => x.Id == d.ObjectId) != null)
                    Fighters.Find(x => x.Id == d.ObjectId).CellId = d.CellId;
                if (Monsters.Find(x => x.Id == d.ObjectId) != null)
                    Monsters.Find(x => x.Id == d.ObjectId).CellId = d.CellId;
                if (Companions.Find(x => x.Id == d.ObjectId) != null)
                    Companions.Find(x => x.Id == d.ObjectId).CellId = d.CellId;

                if (d.ObjectId == Fighter.Id)
                    Fighter.CellId = d.CellId;
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
                Monsters.Clear();
                Companions.Clear();
                foreach (GameFightFighterInformations fighter in message.Fighters)
                    AddFighter(fighter);
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
                    RemoveFighter(message.CharId);
                }
            }
        }

        private void HandleGameFightStartMessage(IAccount account, GameFightStartMessage message)
        {
            WaitForReady = false;
            IsFightStarted = true;
            FightStarted?.Invoke(this);
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
            var fighter = GetFighter(message.TargetId);
            if (Fighter.Id == message.TargetId)
                Logger.Default.Log("Bot mort");
            if (Monsters.Exists(m => m.Id == message.TargetId))
                Logger.Default.Log($"Monstre est mort");
            RemoveFighter(message.TargetId);
        }

        #endregion

        #region Public Fonction
        public IMonster NearestMonster()
        {
            var savDistance = -1;
            foreach (var monster in Monsters)
            {
                if (monster.TeamId == Fighter.TeamId || monster.IsAlive == false)
                    continue;
                var dist = DistanceFrom(monster);
                if ((dist >= savDistance && savDistance != -1) || monster == Fighter) continue;
                savDistance = dist;
                return monster;
            }
            return null;
        }
        public IMonster WeakestMonster()
        {
            Tuple<uint, IMonster> temp = new Tuple<uint, IMonster>(0, null);
            foreach (IMonster m in Fighters)
            {
                if (temp.Item1 > m.LifePoints && m.TeamId != Fighter.TeamId)
                    temp = new Tuple<uint, IMonster>(m.LifePoints, m);
            }
            return temp.Item2;
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
        protected void RemoveFighter(double Id)
        {
            Fighters.Remove(Fighters.Find(f => f.Id == Id));
            Monsters.Remove(Monsters.Find(m => m.Id == Id));
            Companions.Remove(Companions.Find(c => c.Id == Id));
        }
        protected void AddFighter(GameFightFighterInformations infos)
        {
            if (infos is GameFightMonsterInformations monsterInfo)
                Monsters.Add(new Fighters.Monster(monsterInfo.ContextualId, monsterInfo.Disposition.CellId, monsterInfo.Stats, monsterInfo.TeamId, monsterInfo.Alive, monsterInfo.CreatureGenericId, monsterInfo.CreatureGrade));
            else if (infos is GameFightCompanionInformations companionInfo)
                Companions.Add(new Fighters.Companion(companionInfo.ContextualId, companionInfo.Disposition.CellId, companionInfo.Stats, companionInfo.TeamId, companionInfo.Alive, companionInfo.CompanionGenericId, companionInfo.Level, companionInfo.MasterId));
            else
                Fighters.Add(new Fighter(infos.ContextualId, infos.Disposition.CellId, infos.Stats, infos.TeamId, infos.Alive));
        }

        protected int DistanceFrom(IFighter fighter)
        {
            var characterPoint = new MapPoint(Fighter.CellId);
            var testFighterPoint = new MapPoint(fighter.CellId);
            var dist = new SimplePathfinder((API.Gamedata.D2p.Map) Account.Character.Map.Data)
                .FindPath(fighter.CellId, testFighterPoint.CellId).Cells.Count();
            dist += characterPoint.DistanceToCell(testFighterPoint);
            return dist;
        }

        protected IFighter GetFighter(double fighterId)
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