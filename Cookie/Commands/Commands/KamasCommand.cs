using Cookie.Commands.Interfaces;
using Cookie.Core;

namespace Cookie.Commands.Commands
{
    public class KamasCommand : ICommand
    {
        public string CommandName => "kamas";

        public void OnCommand(DofusClient client, string[] args)
        {
            client.Logger.Log($"Vous avez : {client.Account.Character.Stats.Kamas} kamas.",
                LogMessageType.Admin);
        }
    }
}