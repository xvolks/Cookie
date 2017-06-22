using Cookie.Commands.Interfaces;
using Cookie.Core;
using Cookie.Gamedata;

namespace Cookie.Commands.Commands
{
    public class LevelCommand : ICommand
    {
        public string CommandName => "level";

        public void OnCommand(DofusClient client, string[] args)
        {
            client.Logger.Log($"Vous êtes niveau : {client.Account.Character.Level} ",
                LogMessageType.Admin);
        }
    }
}