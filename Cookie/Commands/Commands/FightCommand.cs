using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class FightCommand : ICommand
    {
        private readonly string _commandSufix = "[Fight]";
        public string CommandName => "fight";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Erreur argument command ." + CommandName + ", LogMessageType.Public");
                return;
            }

            account.Character.Map.LaunchAttackByCellId(Convert.ToUInt16(args[0]));
        }
    }
}
