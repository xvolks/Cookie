using Cookie.Commands.Interfaces;
using Cookie.Core;

namespace Cookie.Commands.Commands
{
    public class LevelCommand : ICommand
    {
        public string CommandName => "level";

        public void OnCommand(DofusClient client, string[] args)
        {
            Logger.Default.Log($"Vous êtes niveau : {client.Account.Character.Level} ",
                LogMessageType.Admin);
        }
    }
}