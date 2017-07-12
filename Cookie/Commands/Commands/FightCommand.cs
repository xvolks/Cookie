using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.Core;
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
            if (!(account.Character.Map.Monsters.Count > 0))
            {
                Logger.Default.Log("Aucun monstre sur la map.");
                return;
            }

            if (((Character)account.Character).IA == null)
            {
                ((Character)account.Character).IA = new ArtificialIntelligence();
            }
            ((Character)account.Character).IA.Load(account, args[0]);
            account.Character.Map.LaunchAttack();
        }
    }
}