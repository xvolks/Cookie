using Cookie.API.Commands;
using Cookie.API.Core;

namespace Cookie.Commands.Commands
{
    public class KamasCommand : ICommand
    {
        public string CommandName => "kamas";
        public void OnCommand(IDofusClient client, string[] args)
        {
            client.Log($"Vous avez {client.Account.Character.Stats.Kamas} kamas.");
        }
    }
}
