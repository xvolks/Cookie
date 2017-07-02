using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Game.Entity;
using System.Text;

namespace Cookie.Commands.Commands
{
    public class MapCommand : ICommand
    {
        public string CommandName => "map";
        private string CommandSuffix = "[Map]";

        public void OnCommand(IAccount account, string[] args)
        {
            if (args.Length < 1) PrintError("Vous devez spécifier un argument.");

            switch (args[0])
            {
                case "id":
                    PrintMapId(account);
                    break;
                case "entities":
                    PrintEntities(account);
                    break;
                default:
                    PrintError("Argument inconnue !");
                    break;
            }
        }

        private void PrintMapId(IAccount account)
        {
            var pos = D2OParsing.GetMapCoordinates(account.Character.MapId);
            Logger.Default.Log($"MapID : {account.Character.MapId} | [{pos.X};{pos.Y}]",
                LogMessageType.Admin);
        }

        private void PrintEntities(IAccount account)
        {
            StringBuilder entitiesInfo = new StringBuilder();

            entitiesInfo.AppendLine("ID : CellID");

            foreach (Entity entity in account.Character.Map.Entities)
            {
                entitiesInfo.AppendLine($"\t\t {entity.Id} : {entity.CellId}");
            }

            Logger.Default.Log($"{CommandSuffix} {entitiesInfo.ToString()}");
        }

        private void PrintError(string message)
        {
            Logger.Default.Log($"{CommandSuffix} {message}");
        }
    }
}