using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;

namespace Cookie.Commands.Commands
{
    public class KamasCommand : ICommand
    {
        public string CommandName => "kamas";
        public string ArgsName => "void";

        public void OnCommand(IAccount account, string[] args)
        {
            Logger.Default.Log($"Vous avez {account.Character.Stats.Kamas} kamas.");
        }
    }
}