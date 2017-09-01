using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Datacenter;
using Cookie.API.Game.Fight;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Actions;
using Cookie.API.Protocol.Network.Messages.Game.Actions.Fight;
using Cookie.API.Protocol.Network.Messages.Game.Actions.Sequence;
using Cookie.API.Protocol.Network.Messages.Game.Character.Stats;
using Cookie.API.Protocol.Network.Messages.Game.Context;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Character;
using Cookie.API.Protocol.Network.Types.Game.Actions.Fight;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Game.Fight.Fighters;
using Companion = Cookie.Game.Fight.Fighters.Companion;
using Monster = Cookie.Game.Fight.Fighters.Monster;

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
            TotalLaunchBySpell = new Dictionary<int, int>();
            TotalLaunchByCellBySpell = new Dictionary<int, Dictionary<int, int>>();
            LastTurnLaunchBySpell = new Dictionary<int, int>();
            Options = new List<FightOptionsEnum>();
            DurationByEffect = new Dictionary<int, int>();

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
            Account.Network.RegisterPacket<GameActionFightPointsVariationMessage>(
                HandleGameActionFightPointsVariationMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameActionFightSlideMessage>(HandleGameActionFightSlideMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameActionFightSummonMessage>(HandleGameActionFightSummonMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameActionFightTeleportOnSameMapMessage>(
                HandleGameActionFightTeleportOnSameMapMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightJoinMessage>(HandleGameFightJoinMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightOptionStateUpdateMessage>(HandleGameFightOptionStateUpdateMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameActionFightDispellableEffectMessage>(
                HandleGameActionFightDispellableEffectMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightTurnEndMessage>(HandleGameFightTurnEndMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameMapMovementMessage>(HandleGameMapMovementMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameActionFightSpellCastMessage>(HandleGameActionFightSpellCastMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightStartingMessage>(HandleGameFightStartingMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightTurnReadyRequestMessage>(HandleGameFightTurnReadyRequestMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<GameFightTurnStartPlayingMessage>(HandleGameFightTurnStartPlayingMessage,
                MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<SequenceEndMessage>(HandleSequenceEndMessage, MessagePriority.VeryHigh);

            CheckLock = new object();
        }

        public bool IsFightStarted { get; protected set; }
        public bool IsFighterTurn { get; protected set; }
        public bool WaitForReady { get; protected set; }
        protected object CheckLock { get; set; }
        protected IAccount Account { get; set; }
        public List<IMonster> Monsters { get; protected set; }
        public List<ICompanion> Companions { get; protected set; }
        public Dictionary<int, Dictionary<int, int>> TotalLaunchByCellBySpell { get; protected set; }
        public Dictionary<int, int> TotalLaunchBySpell { get; protected set; }
        public Dictionary<int, int> LastTurnLaunchBySpell { get; set; }
        public List<FightOptionsEnum> Options { get; }
        public Dictionary<int, int> DurationByEffect { get; set; }

        public IFighter Fighter => GetFighter(Account.Character.Id);

        public List<IFighter> Fighters { get; protected set; }
        public int TurnId { get; protected set; }

        public List<IMonster> GetMonsters()
        {
            return Monsters;
        }

        #region Event

        public event Action<GameFightEndMessage> FightEnded;

        public event Action FightStarted;

        public event Action TurnStarted;

        #endregion Event

        #region Handle

        private void HandleGameActionFightPointsVariationMessage(IAccount account,
            GameActionFightPointsVariationMessage message)
        {
            var fighter = (Fighter) GetFighter(message.TargetId);
            if (fighter == null) return;
            switch (message.ActionId)
            {
                case 101:
                case 102:
                case 120:
                    fighter.ActionPoints = (short) (fighter.ActionPoints + message.Delta);
                    break;

                case 78:
                case 127:
                case 129:
                    fighter.MovementPoints = (short) (fighter.MovementPoints + message.Delta);
                    break;
            }
        }

        private void HandleGameActionFightSlideMessage(IAccount account, GameActionFightSlideMessage message)
        {
            var fighter = (Fighter) GetFighter(message.TargetId);
            if (fighter != null)
                fighter.CellId = message.EndCellId;
        }

        private void HandleGameFightTurnReadyRequestMessage(IAccount account, GameFightTurnReadyRequestMessage message)
        {
            account.Network.SendToServer(new GameFightTurnReadyMessage(true));
        }

        private void HandleGameFightTurnStartPlayingMessage(IAccount account, GameFightTurnStartPlayingMessage message)
        {
            TurnStarted?.Invoke();
        }

        private void HandleGameActionFightDispellableEffectMessage(IAccount account,
            GameActionFightDispellableEffectMessage message)
        {
            if (message.Effect is FightTemporaryBoostStateEffect ftbse)
            {
                if (ftbse.TargetId != Fighter.Id) return;
                if (DurationByEffect.ContainsKey(ftbse.StateId))
                    DurationByEffect.Remove(ftbse.StateId);

                DurationByEffect.Add(ftbse.StateId, ftbse.TurnDuration);
            }
            else if (message.Effect is FightTemporaryBoostEffect ftbe)
            {
                switch (message.ActionId)
                {
                    case 168:
                        ((Fighter) Fighter).ActionPoints = (short) (Fighter.ActionPoints - ftbe.Delta);
                        break;
                    case 169:
                        ((Fighter) Fighter).MovementPoints = (short) (Fighter.MovementPoints - ftbe.Delta);
                        break;
                }
            }
        }

        private void HandleGameMapMovementMessage(IAccount account, GameMapMovementMessage message)
        {
            if (Account.Character.Status != CharacterStatus.Fighting) return;
            var clientMovement =
                MapMovementAdapter.GetClientMovement(message.KeyMovements.Select(k => (uint) k).ToList());
            var fighter = (Fighter) GetFighter(message.ActorId);
            if (fighter != null)
                fighter.CellId = clientMovement.CellEnd.CellId;
        }

        private void HandleGameActionFightSpellCastMessage(IAccount account, GameActionFightSpellCastMessage message)
        {
            var fighter = (Fighter) GetFighter(message.SourceId);
            if (fighter == null || Fighter == null || fighter.Id != Fighter.Id) return;
            var spellLevel = -1;
            var spell = Account.Character.Spells.FirstOrDefault(s => s.SpellId == message.SpellId);
            if (spell != null)
                spellLevel = spell.SpellLevel;

            if (spellLevel == -1) return;
            var spellData = ObjectDataManager.Instance.Get<API.Datacenter.Spell>(message.SpellId);
            if (spellData == null) return;
            var spellLevelId = spellData.SpellLevels[spellLevel - 1];
            var spellLevelData = ObjectDataManager.Instance.Get<SpellLevel>(spellLevelId);
            if (spellLevelData == null) return;
            if (spellLevelData.MinCastInterval > 0 &&
                !LastTurnLaunchBySpell.ContainsKey(message.SpellId))
                LastTurnLaunchBySpell.Add(message.SpellId, (int) spellLevelData.MinCastInterval);

            if (TotalLaunchBySpell.ContainsKey(message.SpellId))
                TotalLaunchBySpell[message.SpellId] += 1;
            else
                TotalLaunchBySpell.Add(message.SpellId, 1);

            if (TotalLaunchByCellBySpell.ContainsKey(message.SpellId))
            {
                if (TotalLaunchByCellBySpell[message.SpellId].ContainsKey(message.DestinationCellId))
                    TotalLaunchByCellBySpell[message.SpellId][message.DestinationCellId] += 1;
                else
                    TotalLaunchByCellBySpell[message.SpellId].Add(message.DestinationCellId, 1);
            }
            else
            {
                var tempdico = new Dictionary<int, int> {{message.DestinationCellId, 1}};
                TotalLaunchByCellBySpell.Add(message.SpellId, tempdico);
            }
        }

        private void HandleGameActionFightSummonMessage(IAccount account, GameActionFightSummonMessage message)
        {
            lock (CheckLock)
            {
                foreach (var summon in message.Summons)
                    AddFighter(summon);
            }
        }

        private void HandleGameFightShowFighterMessage(IAccount account, GameFightShowFighterMessage message)
        {
            lock (CheckLock)
            {
                AddFighter(message.Informations);
            }
        }

        private void HandleGameActionFightTeleportOnSameMapMessage(IAccount account,
            GameActionFightTeleportOnSameMapMessage message)
        {
            var fighter = (Fighter) GetFighter(message.TargetId);
            if (fighter != null)
                fighter.CellId = message.CellId;
        }

        private void HandleGameEntitiesDispositionMessage(IAccount account, GameEntitiesDispositionMessage message)
        {
            message.Dispositions.ToList().ForEach(d =>
            {
                var fighter = (Fighter) GetFighter(d.ObjectId);
                if (fighter != null)
                    fighter.CellId = d.CellId;
            });
            Account.Character.Status = CharacterStatus.Fighting;
        }

        private void HandleGameFightJoinMessage(IAccount account, GameFightJoinMessage message)
        {
            lock (CheckLock)
            {
                Fighters.Clear();
                Options.Clear();
                TotalLaunchBySpell.Clear();
                LastTurnLaunchBySpell.Clear();
                TotalLaunchByCellBySpell.Clear();
                DurationByEffect.Clear();
                IsFightStarted = message.IsFightStarted;
                WaitForReady = !message.IsFightStarted && message.CanSayReady;
            }
        }

        private void HandleGameFightOptionStateUpdateMessage(IAccount account,
            GameFightOptionStateUpdateMessage message)
        {
            if (!message.State && Options.Contains((FightOptionsEnum) message.Option))
                Options.Remove((FightOptionsEnum) message.Option);
            if (message.State && !Options.Contains((FightOptionsEnum) message.Option))
                Options.Add((FightOptionsEnum) message.Option);
        }

        private void HandleGameFightTurnStartMessage(IAccount account, GameFightTurnStartMessage message)
        {
            if (!IsFightStarted)
                IsFightStarted = true;

            if (message.ObjectId == Account.Character.Id)
            {
                IsFighterTurn = true;
                Account.Character.Status = CharacterStatus.Fighting;
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
                foreach (var fighter in message.Fighters)
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

        private void HandleGameFightTurnEndMessage(IAccount account, GameFightTurnEndMessage message)
        {
            Account.Character.Status = CharacterStatus.Fighting;
            lock (CheckLock)
            {
                if (message.ObjectId == Account.Character.Id)
                {
                    var num4 = 0;
                    var list = new List<int>();
                    IsFighterTurn = false;
                    TotalLaunchBySpell.Clear();
                    TotalLaunchByCellBySpell.Clear();

                    for (var i = 0; i < DurationByEffect.Keys.Count; i++)
                    {
                        var durationPerEffect = DurationByEffect;
                        num4 = DurationByEffect.Keys.ElementAtOrDefault(i);
                        durationPerEffect[num4] = durationPerEffect[num4] - 1;
                        if (DurationByEffect[DurationByEffect.Keys.ElementAtOrDefault(i)] <= 0)
                            list.Add(DurationByEffect.Keys.ElementAtOrDefault(i));
                    }
                    while (list.Count > 0)
                    {
                        DurationByEffect.Remove(list[0]);
                        list.RemoveAt(0);
                    }

                    for (var i = 0; i < LastTurnLaunchBySpell.Keys.Count; i++)
                    {
                        var dictionary = LastTurnLaunchBySpell;
                        num4 = LastTurnLaunchBySpell.Keys.ElementAtOrDefault(i);
                        dictionary[num4] = dictionary[num4] - 1;
                        if (LastTurnLaunchBySpell[LastTurnLaunchBySpell.Keys.ElementAtOrDefault(i)] <= 0)
                            list.Add(LastTurnLaunchBySpell.Keys.ElementAtOrDefault(i));
                    }
                    while (list.Count > 0)
                    {
                        LastTurnLaunchBySpell.Remove(list[0]);
                        list.RemoveAt(0);
                    }
                }
            }
            var fighter = (Fighter) GetFighter(message.ObjectId);
            if (fighter == null) return;
            fighter.ActionPoints = fighter.Stats.MaxActionPoints;
            fighter.MovementPoints = fighter.Stats.MaxMovementPoints;
        }

        private void HandleGameFightStartMessage(IAccount account, GameFightStartMessage message)
        {
            WaitForReady = false;
            IsFightStarted = true;
        }

        private void HandleGameFightStartingMessage(IAccount account, GameFightStartingMessage message)
        {
            FightStarted?.Invoke();
            Account.Character.Status = CharacterStatus.Fighting;
            Logger.Default.Log("Début du combat");
        }

        private void HandleGameFightEndMessage(IAccount account, GameFightEndMessage message)
        {
            Fighters.Clear();
            Options.Clear();
            TotalLaunchBySpell.Clear();
            LastTurnLaunchBySpell.Clear();
            TotalLaunchByCellBySpell.Clear();
            DurationByEffect.Clear();

            WaitForReady = false;
            IsFighterTurn = false;
            IsFightStarted = false;
            FightEnded?.Invoke(message);

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

        private void HandleSequenceEndMessage(IAccount account, SequenceEndMessage message)
        {
            if (message.AuthorId != account.Character.Id) return;
            account.Network.SendToServer(new GameActionAcknowledgementMessage(true, (sbyte) message.ActionId));
        }

        #endregion Handle

        #region Public Fonction

        public int CanUseSpell(int spellId, IFighter target)
        {
            if (CanLaunchSpell(spellId) != SpellInabilityReason.None)
                return -1;

            if (CanLaunchSpellOn(spellId, Fighter.CellId, target.CellId) == SpellInabilityReason.None)
                return 0;

            var moveCell = -1;
            var distance = -1;
            foreach (var cell in GetReachableCells())
            {
                if (CanLaunchSpellOn(spellId, cell, target.CellId, true) != SpellInabilityReason.None) continue;
                var characterPoint = new MapPoint(cell);
                var tempDistance = characterPoint.DistanceToCell(new MapPoint(target.CellId));

                if (tempDistance <= distance && distance != -1) continue;
                distance = tempDistance;
                moveCell = cell;
            }
            return moveCell;
        }

        public IMonster NearestMonster()
        {
            var charMp = new MapPoint(Fighter.CellId);
            var distance = -1;
            IMonster rMonster = null;

            foreach (var monster in Monsters)
            {
                var monsterMp = new MapPoint(monster.CellId);

                if (distance != -1 && charMp.DistanceToCell(monsterMp) >= distance) continue;
                rMonster = monster;
                distance = charMp.DistanceToCell(monsterMp);
            }

            return rMonster;
        }

        public IMonster WeakestMonster()
        {
            var temp = new Tuple<uint, IMonster>(0, null);
            foreach (var m in Monsters)
                if (temp.Item1 > m.LifePoints && m.TeamId != Fighter.TeamId)
                    temp = new Tuple<uint, IMonster>(m.LifePoints, m);
            return temp.Item2;
        }

        public bool IsHandToHand()
        {
            var characterPoint = new MapPoint(Fighter.CellId);
            var targetPoint = new MapPoint(NearestMonster().CellId);

            return characterPoint.DistanceToCell(targetPoint) <= 1;
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

        #endregion Public Fonction

        #region Protected Fonction

        private int GetInvokationNumber()
        {
            return Monsters.Count(informations => informations.Stats.Summoner == Fighter.Id);
        }

        protected SpellInabilityReason CanLaunchSpell(int spellId)
        {
            short spellLevel;
            try
            {
                spellLevel = Account.Character.Spells.First(s => s.SpellId == spellId).SpellLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return SpellInabilityReason.UnknownSpell;
            }

            var spell = ObjectDataManager.Instance.Get<API.Datacenter.Spell>(spellId);
            var id = Convert.ToInt32(spell.SpellLevels[spellLevel - 1]);
            var spellLevelsData = ObjectDataManager.Instance.Get<SpellLevel>(id);
            if (spellLevelsData == null)
                return SpellInabilityReason.Unknown;
            if (spellId != 0 && Fighter.ActionPoints < spellLevelsData.ApCost)
                return SpellInabilityReason.ActionPoints;
            if (TotalLaunchBySpell.ContainsKey(spellId) &&
                TotalLaunchBySpell[spellId] >= spellLevelsData.MaxCastPerTurn && spellLevelsData.MaxCastPerTurn > 0)
                return SpellInabilityReason.TooManyLaunch;
            lock (CheckLock)
            {
                if (LastTurnLaunchBySpell.ContainsKey(spellId))
                    return SpellInabilityReason.Cooldown;
            }
            var listEffects = spellLevelsData.Effects;
            if (listEffects != null && listEffects.Count > 0 && listEffects[0].EffectId == 181)
            {
                var stats = Account.Character.Stats;
                var total = stats.SummonableCreaturesBoost.Base + stats.SummonableCreaturesBoost.ObjectsAndMountBonus +
                            stats.SummonableCreaturesBoost.AlignGiftBonus + stats.SummonableCreaturesBoost.ContextModif;
                if (GetInvokationNumber() >= total)
                    return SpellInabilityReason.TooManyInvocations;
            }
            lock (CheckLock)
            {
                var listOfStates = spellLevelsData.StatesRequired;
                if (listOfStates.Any(state => !DurationByEffect.ContainsKey(state)))
                    return SpellInabilityReason.RequiredState;
                listOfStates = spellLevelsData.StatesForbidden;
                if (listOfStates.Any(state => DurationByEffect.ContainsKey(state)))
                    return SpellInabilityReason.ForbiddenState;
            }
            return SpellInabilityReason.None;
        }

        protected SpellInabilityReason CanLaunchSpellOn(int spellId, int characterCellId, int cellId,
            bool withMove = false)
        {
            if (!withMove)
            {
                var canLaunchSpell = CanLaunchSpell(spellId);
                if (canLaunchSpell != SpellInabilityReason.None)
                    return canLaunchSpell;
            }
            short spellLevel;
            try
            {
                spellLevel = Account.Character.Spells.First(s => s.SpellId == spellId).SpellLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return SpellInabilityReason.UnknownSpell;
            }

            var spell = ObjectDataManager.Instance.Get<API.Datacenter.Spell>(spellId);
            var id = Convert.ToInt32(spell.SpellLevels[spellLevel - 1]);

            var spellLevelsData = ObjectDataManager.Instance.Get<SpellLevel>( /*spellId */ id);
            if (spellLevelsData == null)
                return SpellInabilityReason.Unknown;
            if (spellId == 0)
                return SpellInabilityReason.UnknownSpell;
            var characterPoint = new MapPoint(characterCellId);
            var targetPoint = new MapPoint(cellId);
            var distanceToTarget = characterPoint.DistanceToCell(targetPoint);
            var minRange = spellLevelsData.MinRange;
            if (spellId != 0 && spellLevelsData.CastInDiagonal)
                minRange = minRange * 2;
            if (minRange < 0)
                minRange = 0;
            var maxRange = spellId != 0
                ? spellLevelsData.Range + (spellLevelsData.RangeCanBeBoosted
                      ? Account.Character.Stats.Range.ObjectsAndMountBonus
                      : 0)
                : spellLevelsData.Range;
            if (spellId != 0 && spellLevelsData.CastInDiagonal)
                maxRange = maxRange * 2;
            if (maxRange < 0)
                maxRange = 0;
            if (distanceToTarget < minRange)
                return SpellInabilityReason.MinRange;
            if (distanceToTarget > maxRange)
                return SpellInabilityReason.MaxRange;
            if (spellId != 0 && spellLevelsData.CastInLine &&
                characterPoint.X != targetPoint.X &&
                characterPoint.Y != targetPoint.Y)
                return SpellInabilityReason.NotInLine;
            if (spellId != 0 && spellLevelsData.CastInDiagonal)
            {
                var list = Dofus1Line.GetLine(characterPoint.X, characterPoint.Y, targetPoint.X, targetPoint.Y);
                var i = 0;
                while (i < list.Count - 1)
                {
                    var actualPoint = (Dofus1Line.Point) list[i];
                    var nextPoint = (Dofus1Line.Point) list[i + 1];
                    i += 1;
                    if (actualPoint.X == nextPoint.X + 1 && actualPoint.Y == nextPoint.Y + 1)
                        continue;
                    if (actualPoint.X == nextPoint.X - 1 && actualPoint.Y == nextPoint.Y - 1)
                        continue;
                    if (actualPoint.X == nextPoint.X + 1 && actualPoint.Y == nextPoint.Y - 1)
                        continue;
                    if (actualPoint.X == nextPoint.X - 1 && actualPoint.Y == nextPoint.Y + 1)
                        continue;
                    return SpellInabilityReason.NotInDiagonal;
                }
            }
            if (spellId != 0 && spellLevelsData.CastTestLos && distanceToTarget > 1)
            {
                var list = Dofus1Line.GetLine(characterPoint.X, characterPoint.Y, targetPoint.X, targetPoint.Y);
                var i = 0;
                while (i < list.Count - 1)
                {
                    var point3 = (Dofus1Line.Point) list[i];
                    var point4 = new MapPoint((int) Math.Round(Math.Floor(point3.X)),
                        (int) Math.Round(Math.Floor(point3.Y)));
                    if (!IsFreeCell(point4.CellId) || !Account.Character.Map.Data.IsLineOfSight(point4.CellId))
                        return SpellInabilityReason.LineOfSight;
                    i += 1;
                }
            }
            if (TotalLaunchByCellBySpell.ContainsKey(spellId) &&
                TotalLaunchByCellBySpell[spellId].ContainsKey(targetPoint.CellId) &&
                TotalLaunchByCellBySpell[spellId][targetPoint.CellId] >= spellLevelsData.MaxCastPerTarget &&
                spellLevelsData.MaxCastPerTarget > 0)
                return SpellInabilityReason.TooManyLaunchOnCell;
            if (IsFreeCell(cellId))
            {
                if (spellLevelsData.NeedTakenCell)
                    return SpellInabilityReason.NeedTakenCell;
            }
            else if (spellLevelsData.NeedFreeCell)
            {
                return SpellInabilityReason.NeedFreeCell;
            }
            return SpellInabilityReason.None;
        }

        protected void RemoveFighter(double Id)
        {
            Fighters.Remove(Fighters.Find(f => f.Id == Id));
            Monsters.Remove(Monsters.Find(m => m.Id == Id));
            Companions.Remove(Companions.Find(c => c.Id == Id));
        }

        protected void AddFighter(GameFightFighterInformations infos)
        {
            if (infos is GameFightMonsterInformations monsterInfo)
                Monsters.Add(new Monster(monsterInfo.ContextualId, monsterInfo.Disposition.CellId, monsterInfo.Stats,
                    monsterInfo.TeamId, monsterInfo.Alive, monsterInfo.CreatureGenericId, monsterInfo.CreatureGrade));
            else if (infos is GameFightCompanionInformations companionInfo)
                Companions.Add(new Companion(companionInfo.ContextualId, companionInfo.Disposition.CellId,
                    companionInfo.Stats, companionInfo.TeamId, companionInfo.Alive, companionInfo.CompanionGenericId,
                    companionInfo.Level, companionInfo.MasterId));
            else
                Fighters.Add(new Fighter(infos.ContextualId, infos.Disposition.CellId, infos.Stats, infos.TeamId,
                    infos.Alive));
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
            return Monsters.Find(x => x.Id == fighterId) != null
                ? Monsters.FirstOrDefault(m => m.Id == fighterId)
                : (Companions.Find(x => x.Id == fighterId) != null
                    ? Companions.FirstOrDefault(c => c.Id == fighterId)
                    : Fighters.FirstOrDefault(f => f.Id == fighterId));
        }

        protected bool IsFreeCell(int cellId)
        {
            return !Fighters.Any(f => f != null && f.CellId == cellId);
        }

        protected bool IsCellWalkable(int cellId)
        {
            lock (CheckLock)
            {
                var mapData = (API.Gamedata.D2p.Map) Account.Character.Map.Data;
                if (!Account.Character.Map.Data.IsWalkable(cellId)) return false;
                var selectedFighter =
                    Fighters.FirstOrDefault(f => f.CellId == cellId ||
                                                 mapData.Cells[cellId].NonWalkableDuringFight);
                return selectedFighter == null;
            }
        }

        #endregion Protected Fonction
    }
}