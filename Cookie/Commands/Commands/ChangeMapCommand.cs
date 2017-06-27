using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Game.Map;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class ChangeMapCommand : ICommand
    {
        public string CommandName => "changemap";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1)
                Logger.Default.Log("Vous devez spécifier la direction pour changer de map (left, right, top, bottom).",
                    LogMessageType.Public);
            else
                switch (args[0])
                {
                    case "top":
                    case "up":
                        account.Character.Map.ChangeMap(MapDirectionEnum.North);
                        break;
                    case "left":
                        account.Character.Map.ChangeMap(MapDirectionEnum.West);
                        break;
                    case "right":
                        account.Character.Map.ChangeMap(MapDirectionEnum.East);
                        break;
                    case "bottom":
                    case "bot":
                        account.Character.Map.ChangeMap(MapDirectionEnum.South);
                        break;
                }
        }
    }
}