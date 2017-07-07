using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.Game.Fight;

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

            new ArtificialIntelligence().Load(account, args[0]);
            account.Character.Map.LaunchAttack();
        }
    }
}