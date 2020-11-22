using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;

namespace Cookie.Commands.Commands
{
    public class LevelCommand : ICommand
    {
        public string CommandName => "level";
        public string ArgsName => "void";


        public void OnCommand(IAccount account, string[] args)
        {
            Logger.Default.Log($"Vous êtes niveau {account.Character.Level}.");
        }
    }
}