using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class DuelCommand : ICommand
    {
        private const string CommandSufix = "[Duel]";
        public string CommandName => "duel";
        public string ArgsName => "string <playerName>";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Erreur argument command ." + CommandName + ", LogMessageType.Public");
                return;
            }

            account.Character.Map.PlayerFightRequest(args[0]);

            Logger.Default.Log($"{CommandSufix} Demande de duel envoyée à <{args[0]}>", LogMessageType.Arena);
        }
    }
}