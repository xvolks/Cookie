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
        private ISpellCast _spellEvent;
        private List<IASpell> _spells;
        private List<IASpell> _iASpells;
        private IASpell _currentSpell;
        private int _currentSpellRelaunch;
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
            _account.Character.Fight.TurnStarted += ExecuteSpell;
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
            bool resetAI = false;
            if (resetAI)
            {
                _account.Character.Fight.FightStarted -= StartFight;
                _account.Character.Fight.TurnStarted -= ExecuteTurn;
                _account.Character.Fight.FightEnded -= FightEnd;
            }
            Logger.Default.Log($"Durée du combat: {TimeSpan.FromMilliseconds(msg.Duration).TotalSeconds} secondes");
            ((Cookie.Core.Frames.BasicFrame)_account.BasicFrame).SpellError -= Frame_SpellError;
        }
        private void StartFight()
        {
            Logger.Default.Log("AI::StartFight()");
            Thread.Sleep(random.Next(1000, 3000));
            _account.Character.Fight.SetReady();
            if (IsHidden)
                HideFight(false);
            if (IsLocked)
                LockFight(false);
            if (PartyOnly)
                LockParty(false);
            ((Cookie.Core.Frames.BasicFrame)_account.BasicFrame).SpellError += Frame_SpellError;
        }
        private void Frame_SpellError(object sender, EventArgs e)
        {
            _account.Character.Fight.EndTurn();
        }
        private void ExecuteTurn()
        {   
            Logger.Default.Log($"Vie du bot: {_account.Character.LifePercentage}, AP[{Fighter.ActionPoints}]");
            if (_spells == null) return;
            _iASpells = _spells.ToList();
            _currentSpell = _iASpells.PopAt(0);
            ExecuteSpell();
        }
        private void ExecuteSpell()
        {
            Logger.Default.Log("ExecuteSpell");
            if(Fighter.ActionPoints <= 0)
            {
                Endturn();
            }
            var monster = _account.Character.Fight.NearestMonster();
            var fighter = (IFighter)monster;
            if(_currentSpell.Target == SpellTarget.Self)
                fighter = Fighter;
            if(_account.Character.Fight.CanLaunchSpell(_currentSpell.SpellId) != SpellInabilityReason.None)  //cant use the spell at all.
            {
                if(GetNextSkill())
                    ExecuteSpell();
                return;
            }
            if (_currentSpell.MoveFirst) //if spell requires move first and we are not beside a mob.
            {
                Logger.Default.Log($"MoveFirst");
                MovementEnum movResults = MoveToHit(_currentSpell.Target == SpellTarget.Self ? (IFighter)monster : fighter, true);
                //No need to Call Execute because we are waiting for the movement.
                if (movResults == MovementEnum.Success)
                {
                    _currentSpell.MoveFirst = false; // already moved.
                    return; // returning so we can wait for the event handler.
                }
                else
                { 
                    if(GetNextSkill())
                        ExecuteSpell();
                    return;
                }
            }
            else if (_currentSpell.HandToHand)
            {
                if (_account.Character.Fight.IsHandToHand())
                    CastSpell(fighter);
                else
                {
                    MovementEnum movResults = MoveToHit(fighter, true);
                    if (movResults != MovementEnum.Success) // If it was a success then we have to wait for the event. Otherwise, next skill.
                        if (GetNextSkill())
                            ExecuteSpell();
                    return;
                }
            }
            else
            {
                SpellInabilityReason reason = _account.Character.Fight.CanLaunchSpellOn(_currentSpell.SpellId, Fighter.CellId, fighter.CellId);
                switch (reason)
                {
                    #region Case Plausible
                    case SpellInabilityReason.MaxRange:
                    case SpellInabilityReason.MinRange:
                    case SpellInabilityReason.LineOfSight:
                    case SpellInabilityReason.NotInDiagonal:
                    case SpellInabilityReason.NotInLine:
                        MovementEnum movResults = MoveToHit(fighter);
                        if (movResults != MovementEnum.Success) // If it was a success then we have to wait for the event. Otherwise, next skill.
                            if (GetNextSkill())
                                ExecuteSpell();
                        return;
                    #endregion
                    case SpellInabilityReason.None:
                        CastSpell(fighter);
                        break;
                    default:
                        if (GetNextSkill())
                            ExecuteSpell();
                        break;
                }
            }
        }
        private void CastSpell(IFighter fighter)
        {
            Logger.Default.Log($"Casting spell {_currentSpell.Name} at {fighter.CellId}");
            _spellEvent = new SpellCast(_account, _currentSpell.SpellId, fighter);
            _spellEvent.SpellCasted += OnSpellCasted;
            _spellEvent.PerformCast();
        }
        private MovementEnum MoveToHit(IFighter fighter, bool handToHand = false)
        {
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
                    if (_account.Character.Fight.CanLaunchSpellOn(_currentSpell.SpellId, destCell, fighter.CellId, true) != SpellInabilityReason.None)
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
                movement.MovementFinished += Movement_MovementFinished;
                movement.PerformMovement();
                return MovementEnum.Success;
            }
            throw new Exception("Movement cannot be null");
        }
        private void Movement_MovementFinished(object sender, CellMovementEventArgs e)
        {
            Thread.Sleep(random.Next(1500, 3000));
            if (e.Sucess)
            {// if movement succefull then Execute spell
                ExecuteSpell();
            }
            else // if not then get next spell and execute.
            {
                if (GetNextSkill())
                    ExecuteSpell();
            }
            return;
        }
        private void OnSpellCasted(object sender, SpellCastEvent e)
        {
            //Fighter.ActionPoints -= (short)_currentSpell.Spell.ApCost;
            System.Threading.Thread.Sleep(random.Next(1000, 2000));
            _spellEvent.SpellCasted -= OnSpellCasted;
            if (e.SpellId == 0)
                Console.WriteLine($"Suceffuly casted {e.SpellId}");
            if (e.Sucess)
            {
                _currentSpellRelaunch++;
                if (_currentSpellRelaunch >= _currentSpell.Relaunchs)// checking if can still relaunch
                {
                    if(GetNextSkill())
                        ExecuteSpell();
                    return;
                }
                ExecuteSpell();
            }
            else
            {
                if (GetNextSkill())
                    ExecuteSpell();
            }
                
        }
        private bool GetNextSkill()
        {
            if (_iASpells.Count > 0)
            {
                _currentSpell = _iASpells.PopAt(0);
                _currentSpellRelaunch = 0;
                return true;
            }
            else
                Endturn();
            return false;
        }
        private void Endturn()
        {
            _account.Network.SendToServer(new GameFightTurnFinishMessage(false));
        }
        private enum MovementEnum : int
        {
            Success = 0,
            NoMovementPoints = 1,
            NotEnoughMovement = 2

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