using Cookie.API.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core.Scripts;

namespace Cookie.Commands.Commands
{
    public class LoadIACommand : ICommand
    {
        public string CommandName => "loadia";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Erreur argument command ." + CommandName + ", LogMessageType.Public");
                return;
            }

            var spells = ScriptsManager.LoadSpellsFromIA($"{args[0]}.lua");

            if (spells == null) return;
            foreach (var spell in spells)
                Logger.Default.Log(
                    $@"Spell ({spell.SpellId}), Target: {spell.Target}, Relaunchs: {spell.Relaunchs}, Condition: {
                            spell.Condition
                        }");
        }
    }
}
