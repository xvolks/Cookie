using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class LevelCommand : ICommand
    {
        public string CommandName => "level";

        public void OnCommand(IDofusClient client, string[] args)
        {
            Logger.Default.Log($"Vous êtes niveau : {client.Account.Character.Level} ",
                LogMessageType.Admin);
        }
    }
}