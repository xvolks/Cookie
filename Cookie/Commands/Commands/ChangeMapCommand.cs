using System.Windows.Forms.VisualStyles;
using Cookie.API.Game.Map;
using Cookie.Commands.Interfaces;
using Cookie.Core;
using Cookie.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class ChangeMapCommand : ICommand
    {
        public string CommandName => "changemap";

        public void OnCommand(DofusClient client, string[] args)
        {
            if (args.Length < 1)
            {
                Logger.Default.Log("Vous devez spécifier la direction pour changer de map (left, right, top, bottom).",
                    LogMessageType.Public);
            }
            else
            {
                switch (args[0])
                {
                    case "top":
                    case "up":
                        client.Account.Character.Map.ChangeMap(MapDirectionEnum.North);
                        break;
                    case "left":
                        client.Account.Character.Map.ChangeMap(MapDirectionEnum.West);
                        break;
                    case "right":
                        client.Account.Character.Map.ChangeMap(MapDirectionEnum.East);
                        break;
                    case "bottom":
                    case "bot":
                        client.Account.Character.Map.ChangeMap(MapDirectionEnum.South);
                        break;

                }
                //if (client.Account.Character.Status == CharacterStatus.None)
            }
        }
    }
}