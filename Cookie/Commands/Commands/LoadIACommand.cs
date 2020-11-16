using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.Core;
using Cookie.Core.Scripts;
using Cookie.Game.Fight;

namespace Cookie.Commands.Commands
{
    public class LoadIACommand : ICommand
    {
        public string CommandName => "loadia";
        public string ArgsName => "string <spellsPath>";


        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Erreur argument command ." + CommandName + ", LogMessageType.Public");
                return;
            }

            var spells = ScriptsManager.LoadSpellsFromIA($"{args[0]}");

            if (spells == null) return;
            foreach (var spell in spells)
                Logger.Default.Log(
                    $@"Spell ({spell.SpellId}), Target: {spell.Target}, Relaunchs: {spell.Relaunchs}, Condition: {
                            spell.HandToHand
                        }");
            if (((Character)account.Character).Ia == null)
                ((Character)account.Character).Ia = new ArtificialIntelligence();
            ((Character)account.Character).Ia.Load(account, args[0]);

        }
    }
}