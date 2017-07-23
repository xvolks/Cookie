using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Core;
using Cookie.API.Game.Fight;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Game.Fight.Spells;
using Cookie.API.Gamedata;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core.Scripts;
using Cookie.Game.Fight.Spell;

namespace Cookie.Game.Fight
{
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        private IAccount _account;

        private IASpell _currentSpell;
        private ISpellCast _spellEvent;
        private List<IASpell> _spells;
        private int _totalSpellLauch;

        public void Load(IAccount account, string path)
        {
            _totalSpellLauch = 0;
            _account = account;
            _spells = ScriptsManager.LoadSpellsFromIA($"{path}.lua");

            var spellsId = _account.Character.Spells.Select(s => s.SpellId).ToList();

            foreach (var spell in _spells)
            {
                if (spellsId.Contains(spell.SpellId)) continue;
                var spellTmp = _spells.FirstOrDefault(s => s.SpellId == spell.SpellId);
                if (spellTmp != null)
                    _spells.Remove(spellTmp);
            }

            /*foreach (var spell in _spells)
            {
                Logger.Default.Log(spell.SpellId.ToString());
            }*/
            _account.Character.Fight.FightStarted += StartFight;
            _account.Character.Fight.TurnStarted += ExecuteSpell;
            _account.Character.Fight.FightEnded += FightEnd;
        }

        private void FightEnd(GameFightEndMessage msg)
        {
            _account.Character.Fight.FightStarted -= StartFight;
            _account.Character.Fight.TurnStarted -= ExecuteSpell;
            _account.Character.Fight.FightEnded -= FightEnd;
            Logger.Default.Log($"Durée du combat: {TimeSpan.FromMilliseconds(msg.Duration).TotalSeconds} secondes");
        }

        private void StartFight()
        {
            _account.Character.Fight.SetReady();
        }

        private void ExecuteSpell()
        {
            Logger.Default.Log($"Vie du bot: {_account.Character.LifePercentage}");
            if (_spells == null) return;
            var monster = _account.Character.Fight.NearestMonster();
            //foreach (var spell in _spells)
            //{
            var spell = _spells[0];
            _currentSpell = spell;
            var fighter = (IFighter) monster;
            if (spell.Target == SpellTarget.Self)
                fighter = _account.Character.Fight.Fighter;
            var useSpell = _account.Character.Fight.CanUseSpell(spell.SpellId, fighter);
            var nameSpell = D2OParsing.GetSpellName(spell.SpellId);
            if (_totalSpellLauch <= spell.Relaunchs)
            {
                Logger.Default.Log($"Attaque {monster.Name}");
                switch (useSpell)
                {
                    case -1:
                        _account.Character.Fight.EndTurn();
                        break;

                    case 0:
                        Logger.Default.Log($"Lancement de {nameSpell}");
                        _spellEvent = new SpellCast(_account, spell.SpellId, fighter.CellId);
                        _spellEvent.SpellCasted += OnSpellCasted;
                        _spellEvent.PerformCast();
                        break;

                    default:
                        Logger.Default.Log($"Déplacement en {useSpell}");
                        var movement = _account.Character.Fight.MoveToCell(useSpell);
                        movement.MovementFinished += (sender, e) =>
                        {
                            if (e.Sucess)
                            {
                                Logger.Default.Log($"Lancement de {nameSpell}");
                                _spellEvent = new SpellCast(_account, spell.SpellId, fighter.CellId);
                                _spellEvent.SpellCasted += OnSpellCasted;
                                _spellEvent.PerformCast();
                            }
                            else
                            {
                                Logger.Default.Log(
                                    $"Erreur lors du lancement du spell {spell.SpellId} sur la cell {fighter.CellId}",
                                    LogMessageType.Public);
                            }
                        };
                        movement.PerformMovement();
                        break;
                }
            }
            else
            {
                _totalSpellLauch = 0;
                _account.Character.Fight.EndTurn();
            }
        }

        private void OnSpellCasted(object sender, SpellCastEvent e)
        {
            _spellEvent.SpellCasted -= OnSpellCasted;
            if (e.Sucess)
            {
                _totalSpellLauch++;
                if (_totalSpellLauch < _currentSpell.Relaunchs)
                {
                    ExecuteSpell();
                }
                else
                {
                    _totalSpellLauch = 0;
                    _account.Character.Fight.EndTurn();
                }
            }
            else
            {
                _totalSpellLauch = 0;
                _account.Character.Fight.EndTurn();
            }
        }
    }
}