using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class MapCommand : ICommand
    {
        private const string CommandSuffix = "[Map]";
        public string CommandName => "map";
        public string ArgsName => "string [id|entities]";

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
                    PrintError("Argument inconnu !");
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
            foreach (var m in account.Character.Map.Monsters)
                Logger.Default.Log($"Groupe de monstre ({m.GroupName}) niveau {m.GroupLevel} sur la cellId {m.CellId}");
            foreach (var n in account.Character.Map.Npcs)
                Logger.Default.Log($"Npc ({n.Name}) sur la cellId {n.CellId}");
            foreach (var p in account.Character.Map.Players)
                Logger.Default.Log($"Joueur ({p.Name}) sur la cellId {p.CellId}");
            foreach (var me in account.Character.Map.Merchants)
                Logger.Default.Log($"Marchand ({me.Name}) sur la cellId {me.CellId}");
            foreach (var e in account.Character.Map.Entities)
                Logger.Default.Log($"Entitée sur la cellId {e.CellId}");
        }

        private void PrintError(string message)
        {
            Logger.Default.Log($"{CommandSuffix} {message}");
        }
    }
}