using System;
using Cookie.Commands.Interfaces;
using Cookie.Core;

namespace Cookie.Commands.Commands
{
    public class GatherCommand : ICommand
    {
        public string CommandName => "gather";

        public void OnCommand(DofusClient client, string[] args)
        {
            if (args.Length < 1)
                client.Logger.Log("Vous devez spécifier l'id de la ressource à récolter.", LogMessageType.Public);
            else
                client.Account.Character.GatherManager.GoGather(Convert.ToInt32(args[0]));
        }
    }
}