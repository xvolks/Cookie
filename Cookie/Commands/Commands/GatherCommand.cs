using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.Core;

namespace Cookie.Commands.Commands
{
    public class GatherCommand : ICommand
    {
        public string CommandName => "gather";

        public void OnCommand(IDofusClient client, string[] args)
        {
            if (args.Length < 1)
                Logger.Default.Log("Vous devez spécifier l'id de la ressource à récolter.", LogMessageType.Public);
            /*else
                client.Account.Character.GatherManager.GoGather(Convert.ToInt32(args[0]));*/
        }
    }
}