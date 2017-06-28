using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class GatherCommand : ICommand
    {
        public string CommandName => "gather";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log(
                    "Vous devez spécifier le ou les id des ressource à récolter. Ou bien stop pour arrêter la récolte.",
                    LogMessageType.Public);
            }
            else
            {
                if (args[0] == "stop")
                {
                    if (account.Character.GatherManager.Launched)
                    {
                        account.Character.GatherManager.Launched = false;
                        account.Character.GatherManager.AutoGather = false;
                        Logger.Default.Log("[GATHER] Récolte terminée!", LogMessageType.Default);
                    }
                    else
                    {
                        Logger.Default.Log("[GATHER] Vous n'êtes pas en récolte impossible d'arrêter.",
                            LogMessageType.Public);
                    }
                }

                else
                {
                    Logger.Default.Log("[GATHER] On commence la Récolte !", LogMessageType.Default);
                    var autogather = args[0] == "true";
                    var list = new List<int>();
                    for (var i = 1; i < args.Length; i++)
                        list.Add(Convert.ToInt32(args[i]));
                    account.Character.GatherManager.Gather(list, autogather);
                }
            }
        }
    }
}