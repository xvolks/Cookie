using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.Core;

namespace Cookie.Commands.Commands
{
    public class KamasCommand : ICommand
    {
        public string CommandName => "kamas";

        public void OnCommand(IDofusClient client, string[] args)
        {
            Logger.Default.Log($"Vous avez : {client.Account.Character.Stats.Kamas} kamas.",
                LogMessageType.Admin);
        }
    }
}