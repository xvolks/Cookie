using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cookie.API.Core;
using Cookie.API.Game.Fight;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.Fight.Spells;
using Cookie.API.Game.Map;
using Cookie.API.Game.World.Pathfinding;
using Cookie.API.Game.World.Pathfinding.Positions;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.API.Utils.Extensions;
using Cookie.Core.Scripts;
using Cookie.Game.Fight.Spell;

namespace Cookie.Game.Fight
{
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        private IAccount _account;
        private readonly Random random = new Random();
        private List<IASpell> _spells;
        private AutoResetEvent MovementAutoReset = new AutoResetEvent(false);
        private readonly int TimeOut = 5000;
        private int Delay => random.Next(500, 1000);
        private CancellationTokenSource CancellationTokenSource;
        private CancellationToken Token => CancellationTokenSource.Token;
        private AutoResetEvent FighterDiedAutoReset => _account.Character.Fight.FighterDiedAutoReset;
        private IFighter Fighter => _account.Character.Fight.Fighter;
        public void Load(IAccount account, string path)
        {
            _account = account;
            _spells = ScriptsManager.LoadSpellsFromIA($"{path}");
            var spellsId = _account.Character.Spells.Select(s => s.SpellId).ToList();

            foreach (var spell in _spells.ToList())
            {
                if (spellsId.Contains(spell.SpellId)) continue;
                var spellTmp = _spells.FirstOrDefault(s => s.SpellId == spell.SpellId);
                if (spellTmp != null)
                    _spells.Remove(spellTmp);
            }

            foreach (var spell in _spells)
            {
                Logger.Default.Log(spell.Name);
            }
            _account.Character.Fight.FightStarted += StartFight;
            _account.Character.Fight.TurnStarted += ExecuteTurn;
            _account.Character.Fight.FightEnded += FightEnd;
        }
        public void Load(IAccount account, List<IASpell> spells)
        {
            _account = account;
            _spells = spells;
            var spellsId = _account.Character.Spells.Select(s => s.SpellId).ToList();

            foreach (var spell in _spells.ToList())
            {
                if (spellsId.Contains(spell.SpellId)) continue;
                var spellTmp = _spells.FirstOrDefault(s => s.SpellId == spell.SpellId);
                if (spellTmp != null)
                    _spells.Remove(spellTmp);
            }

            foreach (var spell in _spells)
            {
                Logger.Default.Log(spell.Name);
            }
            _account.Character.Fight.FightStarted += StartFight;
            _account.Character.Fight.TurnStarted += ExecuteTurn;
            _account.Character.Fight.FightEnded += FightEnd;
        }
        public void RemoveEvents()
        {
            _account.Character.Fight.FightStarted -= StartFight;
            _account.Character.Fight.TurnStarted -= ExecuteTurn;
            _account.Character.Fight.FightEnded -= FightEnd;
        }
        public ArtificialIntelligence()
        {
        }
        private void FightEnd(GameFightEndMessage msg)
        {
            CancellationTokenSource.Cancel();
            Task.Delay(Delay).Wait();
            bool resetAI = false;
            if (resetAI)
            {
                _account.Character.Fight.FightStarted -= StartFight;
                _account.Character.Fight.TurnStarted -= ExecuteTurn;
                _account.Character.Fight.FightEnded -= FightEnd;
            }
            Logger.Default.Log($"Durée du combat: {TimeSpan.FromMilliseconds(msg.Duration).TotalSeconds} secondes");
            //((Cookie.Core.Frames.BasicFrame)_account.BasicFrame).SpellError -= Frame_SpellError;
        }
        private void StartFight()
        {
            CancellationTokenSource = new CancellationTokenSource();
            _account.Character.Status = CharacterStatus.Fighting;
            //Update Weapon
            Logger.Default.Log("AI::StartFight()");
            var objItem = _account.Character.Inventory.Equipment.ToList().FirstOrDefault(x => x.Key == CharacterInventoryPositionEnum.ACCESSORY_POSITION_WEAPON).Value;
            _account.Character.Fight.Weapon = ObjectDataManager.Instance.GetOrDefault<Cookie.API.Datacenter.Weapon>(objItem.ObjectGID);
            Task.Delay(random.Next(1000, 3000)).Wait();
            _account.Character.Fight.SetReady();
            if (IsHidden)
                HideFight(false);
            if (IsLocked)
                LockFight(false);
            if (PartyOnly)
                LockParty(false);
            //((Cookie.Core.Frames.BasicFrame)_account.BasicFrame).SpellError += Frame_SpellError;
        }
        private void Frame_SpellError(object sender, EventArgs e)
        {
            _account.Character.Fight.EndTurn();
        }
        private bool Moving { get; set; }
        private void ExecuteTurn()
        {
            Task.Run(() =>
            {
                Logger.Default.Log($"Vie du bot: {_account.Character.LifePercentage}, AP[{Fighter.ActionPoints}]");
                if (_spells == null) return;
                foreach (var spell in _spells)
                    for (int i = 0; i < spell.Relaunchs; i++)
                    {
                        if (Fighter == null) return;
                        IFighter target = _account.Character.Fight.NearestMonster();
                        if (_account.Character.Fight.CanLaunchSpell(spell.SpellId) != SpellInabilityReason.None) continue;
                        if (spell.MoveFirst && Fighter.MovementPoints > 0 && !_account.Character.Fight.IsHandToHand()) // only move if character is not beside a mob.
                        {
                            MoveClose(target);
                            if(MovementAutoReset.WaitOne(TimeOut)) // Waiting some time for the movementAutoReset to be set. It doesn't matter the outcome we want to call ExecuteSpell
                                Logger.Default.Log($"Movefirst required and finished.", LogMessageType.FightLog);
                        }
                        if (spell.Target == SpellTarget.Self)
                            target = Fighter;
                        ExecuteSpell(spell, target);
                    }
                if (Fighter == null)  return; // in case the fight ends after the last spell was casted.
                // Check weather the bot should move closer to our next target or just pass it's turn.
                if (Fighter.MovementPoints > 0 && 
                    _account.Character.Fight.Fighter.Stats.DodgePALostProbability == 0 && 
                    !_account.Character.Fight.IsHandToHand())
                {
                    IFighter target = _account.Character.Fight.NearestMonster();
                    EventHandler<CellMovementEventArgs> lambda = null;
                    lambda = async (s, e) => {
                        await Task.Delay(Delay);
                        Endturn();
                    };
                    MoveClose(target);
                    return;
                }
                Endturn();

            },Token);
        }
        private void ExecuteSpell(IASpell spell, IFighter target)
        {
            Logger.Default.Log($"ExecuteSpell {spell.Name}");
            if (spell.HandToHand && !_account.Character.Fight.IsHandToHand())
            {
                if (Fighter.MovementPoints > 0 && MoveToHit(target, spell, true) == MovementEnum.Success)
                {
                    if (MovementAutoReset.WaitOne(TimeOut)) // Waiting some time for MovementAnswer finished. If true then call recursively
                    {
                        Logger.Default.Log($"Movement succeeded and Bot is HandToHand to cast {spell.Name}.", LogMessageType.FightLog);
                        ExecuteSpell(spell, target);//in theory it should be HandToHand
                    }// if movement fails let it return let it returns;
                    else
                        Logger.Default.Log($"Movement Failed. Bot couldn't not get HandToHand to cast {spell.Name}.", LogMessageType.FightLog);
                }
                else
                    Logger.Default.Log($"Movement cannot be performed to cast {spell.Name}.", LogMessageType.FightLog);
            }
            else 
            {
                SpellInabilityReason reason = _account.Character.Fight.CanLaunchSpellOn(spell.SpellId, Fighter.CellId, target.CellId);
                switch (reason)
                {
                    case SpellInabilityReason.ActionPoints:
                    case SpellInabilityReason.RequiredState:
                    case SpellInabilityReason.TooManyLaunch:
                    case SpellInabilityReason.TooManyLaunchOnCell:
                    case SpellInabilityReason.Unknown:
                    case SpellInabilityReason.UnknownSpell:
                        // any of those conditions we can't do anything other then going to the next spell. so, let it return;
                        break;
                    case SpellInabilityReason.None:
                        CastSpell(target, spell);
                        if (_account.Character.Fight.SpellResetEvent.WaitOne(TimeOut))
                            Logger.Default.Log($"Successfully launched {spell.Name}", LogMessageType.FightLog);
                        else
                            Logger.Default.Log($"Could not cast {spell.Name} at {target.CellId} ", LogMessageType.FightLog);
                        break;
                    default:
                        if (Fighter.MovementPoints > 0 && MoveToHit(target, spell, false) == MovementEnum.Success)
                            if (MovementAutoReset.WaitOne(TimeOut)) // If movement was a success then we call recursively
                                ExecuteSpell(spell, target);
                        break;
                }
            }
            if (!FighterDiedAutoReset.WaitOne(Delay)) return; // Wait to see if mob died. If true then we Task.Await
            
            Task.Delay(Delay / 2).Wait();
            return;
        }
        private void CastSpell(IFighter fighter, IASpell spell)
        {
            Logger.Default.Log($"Casting spell {spell.Name} at {fighter.CellId}");
            if (spell.SpellId == 0)
                _account.Network.SendToServer(new GameActionFightCastRequestMessage((ushort)spell.SpellId, (short)fighter.CellId));
            else
                _account.Network.SendToServer(new GameActionFightCastOnTargetRequestMessage((ushort)spell.SpellId, fighter.Id));
        }
        private void MoveClose(IFighter target/*, EventHandler<CellMovementEventArgs> eventHandler*/)
        {
            var reachableCells = _account.Character.Fight.GetReachableCells();
            var cellId = -1;
            var savDistance = -1;
            foreach (var cell in reachableCells)
            {
                var reachableCellPoint = new MapPoint(cell);
                var distance = 0;
                distance += reachableCellPoint.DistanceToCell(new MapPoint(target.CellId));
                if (savDistance != -1 && distance >= savDistance) continue;
                cellId = cell;
                savDistance = distance;
            }
            var movement = _account.Character.Fight.MoveToCell(cellId);
            movement.MovementFinished += Movement_MovementFinished;
            movement.PerformMovement();
        }

        private MovementEnum MoveToHit(IFighter fighter, IASpell spell, bool handToHand = false)
        {
            if (Moving) return MovementEnum.AlreadyInMove;
            if (Fighter.MovementPoints <= 0) //not Enough movement points.
            {
                return MovementEnum.NoMovementPoints;
            }
            //Bot has to move somewhere.
            var moveCell = -1;
            var distance = -1; // We gonna be looking for the smaller distance to go in order to be able to cast this _currentSkill
            if (handToHand)
            {
                foreach (var destCell in _account.Character.Fight.GetReachableCells()) // gathering where the bot can go.
                {
                    if (_account.Character.Fight.IsHandToHand(destCell))
                    {//if we gonna be handtohand to the nearestmob then we can break the loop
                        moveCell = destCell;
                        MapPoint characterPoint = new MapPoint(destCell);
                        distance = characterPoint.DistanceToCell(new MapPoint(fighter.CellId));
                        break;
                    }
                }
            }
            else
            {
                foreach (var destCell in _account.Character.Fight.GetReachableCells()) // gathering where the bot can go. Not pathFinding tho.
                {
                    if (_account.Character.Fight.CanLaunchSpellOn(spell.SpellId, destCell, fighter.CellId, true) != SpellInabilityReason.None)
                        continue; //this specific destCell wont let it use this specific skill
                    MapPoint characterPoint = new MapPoint(destCell);
                    int tempDistance = characterPoint.DistanceToCell(new MapPoint(fighter.CellId));

                    if (tempDistance <= distance && distance != -1) continue;
                    distance = tempDistance;
                    moveCell = destCell;

                }

            }
            
            if (moveCell == -1) // even moving wont be able to hit the target
                return MovementEnum.NotEnoughMovement;
             ICellMovement movement = _account.Character.Fight.MoveToCell(moveCell);
            if (movement != null)
            {
                //movement.MovementFinished += (x,e) => 
                //{
                //    Moving = false;
                //    if (e.Sucess) // If success then we send a signal to continue with execution. If it fails let it return null;
                //    {
                //        Logger.Default.Log($"{e.Distance} Mps used Total[{Fighter.MovementPoints}]",LogMessageType.FightLog);
                //        Fighter.MovementPoints -= (short)(e.Distance+1);
                //        movementAutoReset.Set();
                //    }else
                //        Logger.Default.Log($"Movement Performed but failed.", LogMessageType.FightLog);
                //    return;
                //};
                //Moving = true;
                movement.MovementFinished += Movement_MovementFinished;
                movement.PerformMovement();
                return MovementEnum.Success;
            }
            throw new Exception("Movement cannot be null");
        }
        private void Movement_MovementFinished(object sender, CellMovementEventArgs e)
        {
            if (!e.Sucess) return;
            Fighter.MovementPoints = (short)(e.Distance);
            Logger.Default.Log($"Signalig MovementAutoReset", LogMessageType.Divers);
            Task.Delay(Delay).Wait();
            MovementAutoReset.Set();
        }

        private void Endturn()
        {
            Logger.Default.Log($"End of Turn", LogMessageType.FightLog);
            _account.Network.SendToServer(new GameFightTurnFinishMessage(false));
        }
        private enum MovementEnum : int
        {
            Success = 0,
            NoMovementPoints = 1,
            NotEnoughMovement = 2,
            AlreadyInMove = 3

        }
        #region FightSettings
        private bool IsHidden { get; set; }
        internal void HideFight(bool UpdateStatus = true)
        {
            if (UpdateStatus)
                IsHidden = !IsHidden;
            _account.Character.Fight.LockObserver();
        }
        private bool IsLocked { get; set; }
        internal void LockFight(bool UpdateStatus = true)
        {
            if (UpdateStatus)
                IsLocked = !IsLocked;
            _account.Character.Fight.LockFight();
        }
        private bool PartyOnly { get; set; }
        internal void LockParty(bool UpdateStatus = true)
        {
            if(UpdateStatus)
                PartyOnly = !PartyOnly;
            _account.Character.Fight.LockPartyOnly();
        }
        #endregion
    }
}