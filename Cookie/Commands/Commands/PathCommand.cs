using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class PathCommand : ICommand
    {
        public string CommandName => "path";

        public void OnCommand(IDofusClient client, string[] args)
        {
            if (args.Length < 1)
                client.Log("Erreur argument command .path", LogMessageType.Public);
            else
            {
                switch (args[0])
                {
                    case "on":
                        client.Account.Character.PathManager.Start();
                        client.Log("[PathManager] Lancé !");
                        break;
                    case "off":
                        client.Account.Character.PathManager.Stop();
                        client.Log("[PathManager] Arrété !");
                        break;
                    default:
                        client.Log("Erreur command .path", LogMessageType.Public);
                        break;
                }
            }
        }
    }
}
