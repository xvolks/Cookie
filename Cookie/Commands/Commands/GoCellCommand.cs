using System;
using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class GoCellCommand : ICommand
    {
        public string CommandName => "gocell";
        public string ArgsName => "uint [1..559]";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Vous devez spécifier la cellule de destination (1 à 559).",
                    LogMessageType.Public);
            }
            else
            {
                var cell = Convert.ToInt32(args[0]);
                if (cell <= 0 || cell >= 560) return;
                var movement = account.Character.Map.MoveToCell(cell);
                movement.MovementFinished += OnMovementFinished;
                movement.PerformMovement();
            }
        }

        private void OnMovementFinished(object sender, CellMovementEventArgs e)
        {
            switch (e.Sucess)
            {
                case true:
                    Logger.Default.Log($"Déplacement réussi ! Cell d'arrivé: {e.EndCell}");
                    break;
                case false:
                    Logger.Default.Log($"Echec du déplacement :'( StartCell: {e.StartCell} -> EndCell: {e.EndCell}");
                    break;
            }
        }
    }
}