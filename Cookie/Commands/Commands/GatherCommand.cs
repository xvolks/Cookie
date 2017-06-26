using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using System;
using System.Linq;

namespace Cookie.Commands.Commands
{
    public class GatherCommand : ICommand
    {
        public string CommandName => "gather";

        public void OnCommand(IDofusClient client, string[] args)
        {
            if (args.Length < 1)
                    Logger.Default.Log("Vous devez spécifier le ou les id des ressource à récolter. Ou bien stop pour arrêter la récolte.", LogMessageType.Public);
            else
            {
                if (args[0] == "stop")
                {
                    if (client.Account.Character.GatherManager.Launched)
                    {
                        client.Account.Character.GatherManager.Launched = false;
                        Logger.Default.Log("[GATHER] Récolte terminée!", LogMessageType.Default);

                    }
                    else
                        Logger.Default.Log("[GATHER] Vous n'êtes pas en récolte impossible d'arrêter.", LogMessageType.Public);
                }
                    
                else
                {
                    Logger.Default.Log("[GATHER] On commence la Récolte !", LogMessageType.Default);
                    var list = args.Select(arg => Convert.ToInt32(arg)).ToList();
                    client.Account.Character.GatherManager.Gather(list);
                }
            }            
        }
    }
}