using Cookie.API.Commands;
using Cookie.API.Core;
using Cookie.API.Gamedata;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Commands.Commands
{
    public class MapIdCommand : ICommand
    {
        public string CommandName => "mapid";

        public void OnCommand(IAccount account, string[] args)
        {
            var pos = D2OParsing.GetMapCoordinates(account.Character.MapId);
            Logger.Default.Log($"MapID : {account.Character.MapId} | [{pos.X};{pos.Y}]",
                LogMessageType.Admin);
        }
    }
}