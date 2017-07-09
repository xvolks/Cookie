using System;
using Cookie.API.Core;
using Cookie.Core.Scripts;
using System.Collections.Generic;
using Cookie.API.Utils;
using Cookie.API.Gamedata;
using Cookie.API.Game.Fight.Fighters;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight;
using Cookie.API.Game.Fight;

namespace Cookie.Game.Fight
{
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        private IAccount _account;
        private IEnumerable<IASpell> spells;

        public void Load(IAccount account, string path)
        {
            _account = account;
            spells = ScriptsManager.LoadSpellsFromIA($"{path}.lua");
            _account.Character.Fight.FightStarted += new Action(StartFight);
            _account.Character.Fight.TurnStarted += new Action(ExecuteSpell);
            _account.Character.Fight.FightEnded += new Action<GameFightEndMessage>(FightEnd);
        }

        private void FightEnd(GameFightEndMessage msg)
        {
            Logger.Default.Log($"Durée du combat: {msg.Duration}");
        }

        private void StartFight()
        {
            _account.Character.Fight.SetReady();
        }

        private void ExecuteSpell()
        {
            Logger.Default.Log($"Vie du bot: {_account.Character.LifePercentage}");
            if (spells == null) return;
            var monster = _account.Character.Fight.NearestMonster();
            Logger.Default.Log($"Attaque {monster.Name}");
            foreach (var spell in spells)
            {
                var fighter = (IFighter)monster;
                if (spell.Target == SpellTarget.Self)
                    fighter = _account.Character.Fight.Fighter;
                var useSpell = _account.Character.Fight.CanUseSpell(spell.SpellId, fighter);
                var nameSpell = D2OParsing.GetSpellName(spell.SpellId);
                for(int i = 0; i < spell.Relaunchs; i++)
                {
                    Logger.Default.Log($"Lancement de {nameSpell}");
                    switch (useSpell)
                    {
                        case -1:
                            break;
                        case 0:
                            _account.Character.Fight.LaunchSpell(spell.SpellId, fighter.CellId);
                            break;
                        default:
                            if(_account.Character.Fight.MoveToCell(useSpell))
                                _account.Character.Fight.LaunchSpell(spell.SpellId, fighter.CellId);
                            break;
                    }
                }
            }
            _account.Character.Fight.EndTurn();
        }
    }
}
