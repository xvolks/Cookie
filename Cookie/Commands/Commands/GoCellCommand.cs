using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using System;

namespace Cookie.Commands.Commands
{
    public class GoCellCommand : ICommand
    {
        public string CommandName => "gocell";

        public void OnCommand(IDofusClient client, string[] args)
        {
            if (args.Length < 1)
                Logger.Default.Log("Vous devez spécifier la cellule de destination (1 à 559).",
                    LogMessageType.Public);
            else
            {
                var cell = Convert.ToInt32(args[0]);
                if (cell <= 0 || cell >= 560) return;
                if (client.Account.Character.Map.MoveToCell(cell))
                    Logger.Default.Log("Vous êtes bien arrivé!",
                        LogMessageType.Default);
                else
                {
                    Logger.Default.Log("Erreur dans le déplacement de la command gocell.",
                        LogMessageType.Public);
                }
            }
        }
    }
}